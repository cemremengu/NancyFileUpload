namespace NancyFileUpload.Test.Utilities
{
    using System.Collections.Generic;
    using Bootstrapping.Configuration;
    using Nancy;
    using Nancy.Bootstrapper;
    using Nancy.TinyIoc;

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