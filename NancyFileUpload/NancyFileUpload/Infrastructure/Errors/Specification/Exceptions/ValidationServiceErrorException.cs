// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Nancy.Validation;
using NancyFileUpload.Infrastructure.Errors.Exceptions;
using NancyFileUpload.Infrastructure.Errors.Specification.Errors;
using System;
using System.Runtime.Serialization;

namespace NancyFileUpload.Infrastructure.Exceptions.Validations
{
    [Serializable]
    public class ValidationServiceErrorException : HttpServiceErrorException
    {
        public ValidationServiceErrorException(ModelValidationResult modelValidationResult)
            : base(new ValidationServiceError(modelValidationResult))
        {
        }

        public ValidationServiceErrorException(ModelValidationResult modelValidationResult, string message)
            : base(new GeneralServiceError(), message)
        {
        }

        public ValidationServiceErrorException(ModelValidationResult modelValidationResult, string message, Exception innerException)
            : base(new GeneralServiceError(), message, innerException)
        {
        }

        protected ValidationServiceErrorException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
