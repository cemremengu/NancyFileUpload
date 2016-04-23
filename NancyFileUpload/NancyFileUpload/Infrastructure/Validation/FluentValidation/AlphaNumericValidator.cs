// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using FluentValidation.Validators;

namespace NancyFileUpload.Infrastructure.Validation.FluentValidation
{
    public class AlphaNumericValidator : RegularExpressionValidator
    {
        public AlphaNumericValidator() : base("^[a-zA-Z0-9]*$") { }
    }
}