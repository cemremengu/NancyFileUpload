// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NancyFileUpload.Infrastructure.Errors.Enums;

namespace NancyFileUpload.Infrastructure.Errors.Model
{
    public class ServiceErrorModel
    {
        public ServiceErrorModel() { }

        public ServiceErrorModel(ServiceErrorEnum code, string details)
        {
            Code = code;
            Details = details;
        }
        
        public ServiceErrorEnum Code { get; set; }

        public string Details { get; set; }
    }
}
