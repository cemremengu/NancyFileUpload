// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Reflection;
using log4net;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Responses.Negotiation;
using NancyFileUpload.Infrastructure.Errors.Model;
using NancyFileUpload.Infrastructure.Errors.Extensions;
using NancyFileUpload.Infrastructure.Errors.Exceptions;

namespace NancyFileUpload.Infrastructure.Errors.Handler
{
    public static class CustomErrorHandler
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static void Enable(IPipelines pipelines, IResponseNegotiator responseNegotiator, HttpServiceError defaultError)
        {
            if (pipelines == null)
            {
                throw new ArgumentNullException("pipelines");
            }

            if (responseNegotiator == null)
            {
                throw new ArgumentNullException("responseNegotiator");
            }

            if (defaultError == null)
            {
                throw new ArgumentNullException("defaultError");
            }

            pipelines.OnError += (context, exception) => HandleException(context, exception, responseNegotiator, defaultError);
        }

        private static void LogException(NancyContext context, Exception exception)
        {
            if (log.IsErrorEnabled)
            {
                log.ErrorFormat("An exception occured during processing a request. (Exception={0}).", exception);
            }
        }

        private static Response HandleException(NancyContext context, Exception exception, IResponseNegotiator responseNegotiator, HttpServiceError defaultError)
        {
            LogException(context, exception);

            return CreateNegotiatedResponse(context, responseNegotiator, exception, defaultError);
        }

        private static Response CreateNegotiatedResponse(NancyContext context, IResponseNegotiator responseNegotiator, Exception exception, HttpServiceError defaultError)
        {
            HttpServiceError httpServiceError = ExtractFromException(exception, defaultError);

            Negotiator negotiator = new Negotiator(context)
                .WithServiceError(httpServiceError);

            return responseNegotiator.NegotiateResponse(negotiator, context);
        }

        private static HttpServiceError ExtractFromException(Exception exception, HttpServiceError defaultValue)
        {
            HttpServiceError result = defaultValue;

            if (exception != null)
            {
                HttpServiceErrorException exceptionWithServiceError = exception as HttpServiceErrorException;

                if (exceptionWithServiceError != null)
                {
                    result = exceptionWithServiceError.HttpServiceError;
                }
            }

            return result;
        }
    }
}
