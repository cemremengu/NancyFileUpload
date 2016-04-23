// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Nancy.Validation;
using System.Collections.Generic;

namespace NancyFileUpload.Infrastructure.Errors.Specification.Validation
{
    /// <summary>
    /// Converts between the Nancy Representation of Errors and a String Representation.
    /// </summary>
    public class ValidationError
    {
        private readonly IDictionary<string, IList<ModelValidationError>> validationErrors;

        public ValidationError(IDictionary<string, IList<ModelValidationError>> validationErrors)
        {
            this.validationErrors = validationErrors;
        }

        public string ToErrorMessage()
        {
            return string.Format("Validation failed. Properties: ({0})", string.Join(", ", validationErrors.Keys));
        }
    }
}
