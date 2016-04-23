// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Nancy;
using NancyFileUpload.Infrastructure.Settings;
using System;
using System.IO;
using System.Threading.Tasks;

namespace NancyFileUpload.Handlers
{
    public class LocalStorageUploadHandler : IFileUploadHandler
    {
        private readonly IApplicationSettings applicationSettings;
        private readonly IRootPathProvider rootPathProvider;

        public LocalStorageUploadHandler(IApplicationSettings applicationSettings, IRootPathProvider rootPathProvider)
        {
            this.applicationSettings = applicationSettings;
            this.rootPathProvider = rootPathProvider;
        }

        public async Task<FileUploadResult> HandleUpload(string fileName, System.IO.Stream stream)
        {
            string uuid = GetFileName();
            string targetFile = GetTargetFile(uuid);

            using (FileStream destinationStream = File.Create(targetFile))
            {
                await stream.CopyToAsync(destinationStream);
            }

            return new FileUploadResult()
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