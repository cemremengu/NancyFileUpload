namespace NancyFileUpload.Infrastructure.Errors.Specification.Errors
{
    using Enums;
    using Model;
    using Nancy;
    using Nancy.Validation;
    using Validation.Nancy;

    public class ValidationServiceError : HttpServiceError
    {
        public ValidationServiceError(ModelValidationResult modelValidationResult)
        {
            HttpStatusCode = HttpStatusCode.BadRequest;
            ServiceError = new ServiceErrorModel
            {
                Code = ServiceErrorEnum.ValidationError,
                Details = modelValidationResult.GetDetailedErrorMessage()
            };
        }
    }
}