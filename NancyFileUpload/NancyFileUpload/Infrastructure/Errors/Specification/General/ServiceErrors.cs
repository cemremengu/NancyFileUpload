// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NancyFileUpload.Infrastructure.Errors.Model;
using Nancy;
using NancyFileUpload.Infrastructure.Errors.Enums;

namespace NancyFileUpload.Infrastructure.Errors.Specification.General
{
    public static class ServiceErrors
    {
        public static HttpServiceError GeneralServiceError = new HttpServiceError
        {
            HttpStatusCode = HttpStatusCode.BadRequest,
            ServiceError = new ServiceErrorModel { 
                Code = ServiceErrorEnum.GeneralError,
                Details = "An Error occured."
            }
        };
    }
}
