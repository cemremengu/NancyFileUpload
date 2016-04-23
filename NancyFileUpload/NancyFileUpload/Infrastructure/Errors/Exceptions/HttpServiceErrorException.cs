// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NancyFileUpload.Infrastructure.Errors.Model;
using System;
using System.Runtime.Serialization;

namespace NancyFileUpload.Infrastructure.Errors.Exceptions
{
    [Serializable]
    public abstract class HttpServiceErrorException : Exception
    {
        public readonly HttpServiceError HttpServiceError;

        public HttpServiceErrorException(HttpServiceError serviceError)
            : base() 
        {
            this.HttpServiceError = serviceError;
        }

        public HttpServiceErrorException(HttpServiceError serviceError, string message)
            : base(message) 
        {
            this.HttpServiceError = serviceError;
        }

        public HttpServiceErrorException(HttpServiceError serviceError, string message, Exception innerException)
            : base(message, innerException) 
        {
            this.HttpServiceError = serviceError;
        }


        protected HttpServiceErrorException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }
    }
}