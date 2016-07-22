namespace NancyFileUpload.Infrastructure.Errors.Extensions
{
    using Model;
    using Nancy;
    using Nancy.Responses.Negotiation;

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