namespace NancyFileUpload.Infrastructure.Errors.Specification.Exceptions
{
    using System;
    using System.Runtime.Serialization;
    using Errors;
    using Infrastructure.Errors.Exceptions;

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