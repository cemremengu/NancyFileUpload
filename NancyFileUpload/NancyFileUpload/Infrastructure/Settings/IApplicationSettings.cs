// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NancyFileUpload.Infrastructure.Domain;

namespace NancyFileUpload.Infrastructure.Settings
{
    public interface IApplicationSettings
    {
        string FileUploadDirectory { get; }

         FileSize MaxFileSizeForUpload { get; }
    }
}
