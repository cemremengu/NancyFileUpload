// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NancyFileUpload.Infrastructure.Errors.Enums;
using NancyFileUpload.Infrastructure.Errors.Model;

namespace NancyFileUpload.Infrastructure.Errors.Specification.Errors
{
    public class GeneralServiceError : HttpServiceError
    {
        public GeneralServiceError()
        {
            HttpStatusCode = Nancy.HttpStatusCode.BadRequest;
            ServiceError = new ServiceErrorModel
            {
                Code = ServiceErrorEnum.GeneralError,
                Details = "An Error occured."
            };
        }
    }
}
