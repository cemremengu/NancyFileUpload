// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NancyFileUpload.Infrastructure.Errors.Exceptions;
using NancyFileUpload.Infrastructure.Errors.Specification.Errors;
using System;
using System.Runtime.Serialization;

namespace NancyFileUpload.Infrastructure.Exceptions.Validations
{
    [Serializable]
    public class GeneralServiceErrorException : HttpServiceErrorException
    {
        public GeneralServiceErrorException()
            : base(new GeneralServiceError()) 
        {
        }

        public GeneralServiceErrorException(string message)
            : base(new GeneralServiceError(), message) 
        {
        }

        public GeneralServiceErrorException(string message, Exception innerException)
            : base(new GeneralServiceError(), message, innerException) 
        {
        }

        protected GeneralServiceErrorException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }
    }
}
