// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Nancy;

namespace NancyFileUpload.Infrastructure.Errors.Model
{
    public class HttpServiceError
    {
        public HttpServiceError() { }

        public HttpServiceError(HttpStatusCode httpStatusCode, ServiceErrorModel serviceError)
        {
            HttpStatusCode = httpStatusCode;
            ServiceError = serviceError;
        }

        public HttpStatusCode HttpStatusCode { get; set; }

        public ServiceErrorModel ServiceError { get; set; }
    }
}
