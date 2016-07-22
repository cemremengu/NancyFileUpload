namespace NancyFileUpload.Infrastructure.Errors.Model
{
    using Enums;

    public class ServiceErrorModel
    {
        public ServiceErrorModel()
        {
        }

        public ServiceErrorModel(ServiceErrorEnum code, string details)
        {
            Code = code;
            Details = details;
        }

        public ServiceErrorEnum Code { get; set; }

        public string Details { get; set; }
    }
}