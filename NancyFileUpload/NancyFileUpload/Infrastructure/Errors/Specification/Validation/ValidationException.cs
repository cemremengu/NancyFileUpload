using Nancy;
using NancyFileUpload.Infrastructure.Errors.Enums;
using NancyFileUpload.Infrastructure.Errors.Exceptions;
using NancyFileUpload.Infrastructure.Errors.Model;
using NancyFileUpload.Infrastructure.Errors.Specification.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NancyFileUpload.Infrastructure.Exceptions.Validations
{
    public class ValidationException : HttpServiceErrorException
    {
        public ValidationException(ValidationError validationError)
            : base(Create(validationError))
        {
        }

        private static HttpServiceError Create(ValidationError validationError)
        {
            var serviceError = new ServiceErrorModel(ServiceErrorEnum.ValidationError, validationError.ToErrorMessage());

            return new HttpServiceError(HttpStatusCode.BadRequest, serviceError);
        }
    }
}
