// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Nancy;
using Nancy.Bootstrapper;
using Nancy.Responses.Negotiation;
using Nancy.TinyIoc;
using NancyFileUpload.Infrastructure.Domain;
using NancyFileUpload.Infrastructure.Errors.Handler;
using NancyFileUpload.Infrastructure.Errors.Specification.General;
using NancyFileUpload.Infrastructure.Settings;


namespace NancyFileUpload.Web
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override NancyInternalConfiguration InternalConfiguration
        {
            get
            {
                return NancyInternalConfiguration.WithOverrides(config =>
                {
                    config.ResponseProcessors = new[] { typeof(JsonProcessor), typeof(XmlProcessor) };
                });
            }
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            container.Register<IApplicationSettings>(new ApplicationSettings("uploads", FileSize.Create(2, FileSize.Unit.Megabyte)));
        }

        protected override void RequestStartup(TinyIoCContainer container, IPipelines pipelines, NancyContext context)
        {
            CustomErrorHandler.Enable(pipelines, container.Resolve<IResponseNegotiator>(), ServiceErrors.GeneralServiceError);
        }

    }
}
