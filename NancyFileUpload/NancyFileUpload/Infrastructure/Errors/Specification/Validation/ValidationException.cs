// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Nancy;
using NancyFileUpload.Infrastructure.Errors.Enums;
using NancyFileUpload.Infrastructure.Errors.Exceptions;
using NancyFileUpload.Infrastructure.Errors.Model;
using NancyFileUpload.Infrastructure.Errors.Specification.Validation;

namespace NancyFileUpload.Infrastructure.Exceptions.Validations
{
    public class ValidationException : HttpServiceErrorException
    {
        public ValidationException(ValidationError validationError)
            : base(Create(validationError))
        {
        }

        private static HttpServiceError Create(ValidationError validationError)
        {
            var serviceError = new ServiceErrorModel(ServiceErrorEnum.ValidationError, validationError.ToErrorMessage());

            return new HttpServiceError(HttpStatusCode.BadRequest, serviceError);
        }
    }
}
