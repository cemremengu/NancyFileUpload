namespace NancyFileUpload.Infrastructure.Errors.Handler
{
    using System;
    using System.Reflection;
    using Exceptions;
    using Extensions;
    using log4net;
    using Model;
    using Nancy;
    using Nancy.Bootstrapper;
    using Nancy.Responses.Negotiation;

    public static class CustomErrorHandler
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static void Enable(IPipelines pipelines, IResponseNegotiator responseNegotiator,
            HttpServiceError defaultError)
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

            pipelines.OnError +=
                (context, exception) => HandleException(context, exception, responseNegotiator, defaultError);
        }

        private static void LogException(NancyContext context, Exception exception)
        {
            if (log.IsErrorEnabled)
            {
                log.ErrorFormat("An exception occured during processing a request. (Exception={0}).", exception);
            }
        }

        private static Response HandleException(NancyContext context, Exception exception,
            IResponseNegotiator responseNegotiator, HttpServiceError defaultError)
        {
            LogException(context, exception);

            return CreateNegotiatedResponse(context, responseNegotiator, exception, defaultError);
        }

        private static Response CreateNegotiatedResponse(NancyContext context, IResponseNegotiator responseNegotiator,
            Exception exception, HttpServiceError defaultError)
        {
            var httpServiceError = ExtractFromException(exception, defaultError);

            var negotiator = new Negotiator(context)
                .WithServiceError(httpServiceError);

            return responseNegotiator.NegotiateResponse(negotiator, context);
        }

        private static HttpServiceError ExtractFromException(Exception exception, HttpServiceError defaultValue)
        {
            var result = defaultValue;

            if (exception != null)
            {
                var exceptionWithServiceError = exception as HttpServiceErrorException;

                if (exceptionWithServiceError != null)
                {
                    result = exceptionWithServiceError.HttpServiceError;
                }
            }

            return result;
        }
    }
}