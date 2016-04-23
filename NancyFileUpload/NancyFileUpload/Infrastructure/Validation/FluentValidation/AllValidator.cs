// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Linq;
using System.Collections.Generic;
using FluentValidation.Validators;

namespace NancyFileUpload.Infrastructure.Validation.FluentValidation
{
    public class AllValidator<TProperty> : PropertyValidator
    {
        private Func<TProperty, bool> predicate;

        public AllValidator(Func<TProperty, bool> predicate, string message)
            : base(message)
        {
            this.predicate = predicate;
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            var list = context.PropertyValue as IEnumerable<TProperty>;

            if(list == null) 
            {
                return false;
            }

            return list.All(predicate);
        }
    }
}