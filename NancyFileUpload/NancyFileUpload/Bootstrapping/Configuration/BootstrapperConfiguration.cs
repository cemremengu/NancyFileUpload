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

namespace NancyFileUpload.Bootstrapping.Configuration
{
    public class BootstrapperConfiguration : IBootstrapperConfiguration
    {
        public void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            container.Register<IApplicationSettings>(new ApplicationSettings("uploads", FileSize.Create(2, FileSize.Unit.Megabyte)));
        }

        public void ConfigureRequestContainer(TinyIoCContainer container, IPipelines pipelines, NancyContext context)
        {
        }
    }
}