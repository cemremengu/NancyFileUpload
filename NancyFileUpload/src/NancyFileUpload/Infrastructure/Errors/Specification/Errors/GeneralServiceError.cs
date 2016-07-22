namespace NancyFileUpload.Infrastructure.Errors.Specification.Errors
{
    using Enums;
    using Model;
    using Nancy;

    public class GeneralServiceError : HttpServiceError
    {
        public GeneralServiceError()
        {
            HttpStatusCode = HttpStatusCode.BadRequest;
            ServiceError = new ServiceErrorModel
            {
                Code = ServiceErrorEnum.GeneralError,
                Details = "An Error occured."
            };
        }
    }
}