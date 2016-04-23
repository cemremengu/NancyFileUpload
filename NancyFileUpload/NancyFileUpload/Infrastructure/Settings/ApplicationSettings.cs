// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NancyFileUpload.Infrastructure.Domain;

namespace NancyFileUpload.Infrastructure.Settings
{
    public class ApplicationSettings : IApplicationSettings
    {
        private readonly string uploadDirectory;
        private readonly FileSize fileSize;

        public ApplicationSettings(string uploadDirectory, FileSize fileSize)
        {
            this.uploadDirectory = uploadDirectory;
            this.fileSize = fileSize;
        }

        public string FileUploadDirectory
        {
            get { return uploadDirectory; }
        }

        public FileSize MaxFileSizeForUpload
        {
            get { return fileSize; }
        }
    }
}
