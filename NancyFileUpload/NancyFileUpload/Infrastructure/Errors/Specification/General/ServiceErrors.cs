using NancyFileUpload.Infrastructure.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;
using NancyFileUpload.Infrastructure.Errors.Enums;


namespace NancyFileUpload.Infrastructure.Errors.Specification.General
{
    public static class ServiceErrors
    {
        public static HttpServiceError GeneralServiceError = new HttpServiceError
        {
            HttpStatusCode = HttpStatusCode.BadRequest,
            ServiceError = new ServiceErrorModel { 
                Code = ServiceErrorEnum.GeneralError,
                Details = "An Error occured."
            }
        };
    }
}
