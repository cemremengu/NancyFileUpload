namespace NancyFileUpload.Modules
{
    using Handlers;
    using Infrastructure.Validation.Nancy;
    using Nancy;
    using Requests;
    using Responses;

    public class FileUploadModule : NancyModule
    {
        private readonly IFileUploadHandler _fileUploadHandler;

        public FileUploadModule(IFileUploadHandler fileUploadHandler)
            : base("/file")
        {
            _fileUploadHandler = fileUploadHandler;

            Post("/upload", async (args, ct) =>
            {
                var request = this.CustomBindAndValidate<FileUploadRequest>();

                var uploadResult = await fileUploadHandler.HandleUpload(request.File.Name, request.File.Value);

                var response = new FileUploadResponse {Identifier = uploadResult.Identifier};

                return Negotiate
                    .WithStatusCode(HttpStatusCode.OK)
                    .WithModel(response);
            });
        }
    }
}