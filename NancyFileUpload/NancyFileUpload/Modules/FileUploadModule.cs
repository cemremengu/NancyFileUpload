// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Nancy;
using Nancy.ModelBinding;
using NancyFileUpload.Handlers;
using NancyFileUpload.Infrastructure.Validation.Nancy;
using NancyFileUpload.Requests;
using NancyFileUpload.Responses;

namespace NancyFileUpload.Modules
{
    public class FileUploadModule : NancyModule
    {
        private readonly IFileUploadHandler fileUploadHandler;

        public FileUploadModule(IFileUploadHandler fileUploadHandler)
            : base("/file")
        {
            this.fileUploadHandler = fileUploadHandler;

            Post["/upload", true] = async (x, ct) =>
            {
                var request = this.CustomBindAndValidate<FileUploadRequest>();

                var uploadResult = await fileUploadHandler.HandleUpload(request.File.Name, request.File.Value);

                var response = new FileUploadResponse() { Identifier = uploadResult.Identifier };

                return Negotiate
                    .WithStatusCode(HttpStatusCode.OK)
                    .WithModel(response);
            };
        }
    }
}
