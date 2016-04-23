using Nancy;
using Nancy.Bootstrapper;
using Nancy.Responses.Negotiation;
using Nancy.TinyIoc;
using NancyFileUpload.Infrastructure.Errors.Handler;
using NancyFileUpload.Infrastructure.Errors.Specification.General;
using System.Collections.Generic;

namespace NancyFileUpload.Test.Bootstrapping
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

        private readonly IEnumerable<InstanceRegistration> registrations;

        public Bootstrapper(IEnumerable<InstanceRegistration> registrations)
        {
            this.registrations = registrations;
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            foreach (var registration in registrations)
            {
                container.Register(registration.RegistrationType, registration.Implementation);
            }
        }

        protected override void RequestStartup(TinyIoCContainer container, IPipelines pipelines, NancyContext context)
        {
            CustomErrorHandler.Enable(pipelines, container.Resolve<IResponseNegotiator>(), ServiceErrors.GeneralServiceError);
        }
    }
}
