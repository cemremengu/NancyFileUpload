namespace NancyFileUpload.Bootstrapping.Configuration
{
    using Nancy;
    using Nancy.Bootstrapper;
    using Nancy.TinyIoc;

    public interface IBootstrapperConfiguration
    {
        void ConfigureApplicationContainer(TinyIoCContainer container);

        void ConfigureRequestContainer(TinyIoCContainer container, IPipelines pipelines, NancyContext context);
    }
}