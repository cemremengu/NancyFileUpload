// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Nancy.Validation;
using System.Linq;


namespace NancyFileUpload.Infrastructure.Validation.Nancy
{
    public static class ModelValidationResultExtensions
    {
        public static string GetDetailedErrorMessage(this ModelValidationResult modelValidationResult)
        {
            var formattedErrors = modelValidationResult.Errors
                .Select(x => new { Key = x.Key, Errors = x.Value.Select(y => y.ErrorMessage) })
                .Select(x => string.Format("Parameter = {0}, Errors = ({1})", x.Key, string.Join(", ", x.Errors)));

            return string.Format("Validation failed for Request Parameters: ({0})", 
                string.Join(", ", formattedErrors));
        }
    }
}
