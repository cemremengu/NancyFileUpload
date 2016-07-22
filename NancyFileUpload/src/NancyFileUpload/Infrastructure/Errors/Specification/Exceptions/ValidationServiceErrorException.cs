namespace NancyFileUpload.Infrastructure.Errors.Specification.Exceptions
{
    using System;
    using System.Runtime.Serialization;
    using Errors;
    using Infrastructure.Errors.Exceptions;
    using Nancy.Validation;

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

        public ValidationServiceErrorException(ModelValidationResult modelValidationResult, string message,
            Exception innerException)
            : base(new GeneralServiceError(), message, innerException)
        {
        }

        protected ValidationServiceErrorException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}