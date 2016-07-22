namespace NancyFileUpload.Infrastructure.Settings
{
    using Domain;

    public interface IApplicationSettings
    {
        string FileUploadDirectory { get; }

        FileSize MaxFileSizeForUpload { get; }
    }
}