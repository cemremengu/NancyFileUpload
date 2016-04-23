// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using NancyFileUpload.Bootstrapping.Configuration;
using System.Collections.Generic;

namespace NancyFileUpload.Test.Utilities
{
    public class TestBootstrapperConfiguration : IBootstrapperConfiguration
    {
        private readonly IEnumerable<InstanceRegistration> registrations;

        public TestBootstrapperConfiguration(IEnumerable<InstanceRegistration> registrations)
        {
            this.registrations = registrations;
        }

        public void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            foreach (var registration in registrations)
            {
                container.Register(registration.RegistrationType, registration.Implementation);
            }
        }

        public void ConfigureRequestContainer(TinyIoCContainer container, IPipelines pipelines, NancyContext context)
        {
            // Do not modify original pipeline ...
        }
    }
}
