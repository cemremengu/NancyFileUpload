// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Nancy.Validation;
using NancyFileUpload.Infrastructure.Errors.Enums;
using NancyFileUpload.Infrastructure.Errors.Model;
using NancyFileUpload.Infrastructure.Validation.Nancy;

namespace NancyFileUpload.Infrastructure.Errors.Specification.Errors
{
    public class ValidationServiceError : HttpServiceError
    {
        public ValidationServiceError(ModelValidationResult modelValidationResult)
        {
            HttpStatusCode = Nancy.HttpStatusCode.BadRequest;
            ServiceError = new ServiceErrorModel
            {
                Code = ServiceErrorEnum.ValidationError,
                Details = modelValidationResult.GetDetailedErrorMessage()
            };
        }
    }
}
