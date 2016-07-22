namespace NancyFileUpload.Bootstrapping.Configuration
{
    using Infrastructure.Domain;
    using Infrastructure.Settings;
    using Nancy;
    using Nancy.Bootstrapper;
    using Nancy.TinyIoc;

    public class BootstrapperConfiguration : IBootstrapperConfiguration
    {
        public void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            container.Register<IApplicationSettings>(new ApplicationSettings("uploads",
                FileSize.Create(2, FileSize.Unit.Megabyte)));
        }

        public void ConfigureRequestContainer(TinyIoCContainer container, IPipelines pipelines, NancyContext context)
        {
        }
    }
}