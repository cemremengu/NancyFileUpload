// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NancyFileUpload.Infrastructure.Domain;
using System;

namespace NancyFileUpload.Infrastructure.Settings
{
    public class ApplicationSettings : IApplicationSettings
    {
        private readonly string uploadDirectory;
        private readonly FileSize fileSize;

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
