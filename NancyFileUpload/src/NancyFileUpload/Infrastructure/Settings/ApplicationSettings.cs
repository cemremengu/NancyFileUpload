namespace NancyFileUpload.Infrastructure.Settings
{
    using System;
    using Domain;

    public class ApplicationSettings : IApplicationSettings
    {
        public ApplicationSettings(string uploadDirectory, FileSize fileSize)
        {
            if (uploadDirectory == null)
            {
                throw new ArgumentNullException("uploadDirectory");
            }
            if (fileSize == null)
            {
                throw new ArgumentNullException("fileSize");
            }
            FileUploadDirectory = uploadDirectory;
            MaxFileSizeForUpload = fileSize;
        }

        public string FileUploadDirectory { get; }

        public FileSize MaxFileSizeForUpload { get; }
    }
}