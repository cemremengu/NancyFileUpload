namespace NancyFileUpload.Infrastructure.Errors.Model
{
    using Nancy;

    public class HttpServiceError
    {
        public HttpServiceError()
        {
        }

        public HttpServiceError(HttpStatusCode httpStatusCode, ServiceErrorModel serviceError)
        {
            HttpStatusCode = httpStatusCode;
            ServiceError = serviceError;
        }

        public HttpStatusCode HttpStatusCode { get; set; }

        public ServiceErrorModel ServiceError { get; set; }
    }
}