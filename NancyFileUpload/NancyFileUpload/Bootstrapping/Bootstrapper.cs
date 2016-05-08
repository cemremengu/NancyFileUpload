// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Nancy;
using Nancy.Bootstrapper;
using Nancy.Responses.Negotiation;
using Nancy.TinyIoc;
using NancyFileUpload.Bootstrapping.Configuration;
using NancyFileUpload.Infrastructure.Errors.Handler;
using NancyFileUpload.Infrastructure.Errors.Specification.Errors;

namespace NancyFileUpload.Bootstrapping
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

        private readonly IBootstrapperConfiguration configuration;

        public Bootstrapper(IBootstrapperConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            // Make custom registrations:
            configuration.ConfigureApplicationContainer(container);
        }

        protected override void RequestStartup(TinyIoCContainer container, IPipelines pipelines, NancyContext context)
        {
            // Add the Common Error Handling Pipeline:
            CustomErrorHandler.Enable(pipelines, container.Resolve<IResponseNegotiator>(), new GeneralServiceError());
            
            // Make custom registrations:
            configuration.ConfigureRequestContainer(container, pipelines, context);
        }
    }
}
