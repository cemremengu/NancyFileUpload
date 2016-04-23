// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Nancy;
using Nancy.Responses.Negotiation;
using NancyFileUpload.Infrastructure.Errors.Model;

namespace NancyFileUpload.Infrastructure.Errors.Extensions
{
    public static class NegotiatorExtensions
    {
        public static Negotiator WithServiceError(this Negotiator negotiator, HttpServiceError httpServiceError)
        {
            return negotiator
                .WithStatusCode(httpServiceError.HttpStatusCode)
                .WithModel(httpServiceError.ServiceError);
        }
    }
}
