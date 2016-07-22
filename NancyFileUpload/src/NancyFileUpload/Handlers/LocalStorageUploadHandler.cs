namespace NancyFileUpload.Handlers
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Infrastructure.Settings;
    using Nancy;

    public class LocalStorageUploadHandler : IFileUploadHandler
    {
        private readonly IApplicationSettings applicationSettings;
        private readonly IRootPathProvider rootPathProvider;

        public LocalStorageUploadHandler(IApplicationSettings applicationSettings, IRootPathProvider rootPathProvider)
        {
            this.applicationSettings = applicationSettings;
            this.rootPathProvider = rootPathProvider;
        }

        public async Task<FileUploadResult> HandleUpload(string fileName, Stream stream)
        {
            var uuid = GetFileName();
            var targetFile = GetTargetFile(uuid);

            using (var destinationStream = File.Create(targetFile))
            {
                await stream.CopyToAsync(destinationStream);
            }

            return new FileUploadResult
            {
                Identifier = uuid
            };
        }

        private string GetTargetFile(string fileName)
        {
            return Path.Combine(GetUploadDirectory(), fileName);
        }

        private string GetFileName()
        {
            return Guid.NewGuid().ToString();
        }

        private string GetUploadDirectory()
        {
            var uploadDirectory = Path.Combine(rootPathProvider.GetRootPath(), applicationSettings.FileUploadDirectory);

            if (!Directory.Exists(uploadDirectory))
            {
                Directory.CreateDirectory(uploadDirectory);
            }

            return uploadDirectory;
        }
    }
}