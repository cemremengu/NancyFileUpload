namespace NancyFileUpload.Handlers
{
    using System.IO;
    using System.Threading.Tasks;

    public interface IFileUploadHandler
    {
        Task<FileUploadResult> HandleUpload(string fileName, Stream stream);
    }
}