namespace NancyFileUpload.Bootstrapping
{
    using System;
    using Configuration;
    using Infrastructure.Errors.Handler;
    using Infrastructure.Errors.Specification.Errors;
    using Nancy;
    using Nancy.Bootstrapper;
    using Nancy.Responses.Negotiation;
    using Nancy.TinyIoc;

    public class Bootstrapper : DefaultNancyBootstrapper
    {
        private readonly IBootstrapperConfiguration configuration;

        public Bootstrapper(IBootstrapperConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override Func<ITypeCatalog, NancyInternalConfiguration> InternalConfiguration
        {
            get
            {
                return
                    NancyInternalConfiguration.WithOverrides(
                        config => { config.ResponseProcessors = new[] {typeof(JsonProcessor), typeof(XmlProcessor)}; });
            }
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