namespace NancyFileUpload.Infrastructure.Errors.Exceptions
{
    using System;
    using System.Runtime.Serialization;
    using Model;

    [Serializable]
    public abstract class HttpServiceErrorException : Exception
    {
        public readonly HttpServiceError HttpServiceError;

        public HttpServiceErrorException(HttpServiceError serviceError)
        {
            HttpServiceError = serviceError;
        }

        public HttpServiceErrorException(HttpServiceError serviceError, string message)
            : base(message)
        {
            HttpServiceError = serviceError;
        }

        public HttpServiceErrorException(HttpServiceError serviceError, string message, Exception innerException)
            : base(message, innerException)
        {
            HttpServiceError = serviceError;
        }


        protected HttpServiceErrorException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}