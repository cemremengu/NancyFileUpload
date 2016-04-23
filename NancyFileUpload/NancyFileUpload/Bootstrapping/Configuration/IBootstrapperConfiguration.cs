// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;

namespace NancyFileUpload.Bootstrapping.Configuration
{
    public interface IBootstrapperConfiguration
    {
        void ConfigureApplicationContainer(TinyIoCContainer container);

        void ConfigureRequestContainer(TinyIoCContainer container, IPipelines pipelines, NancyContext context);
    }
}
