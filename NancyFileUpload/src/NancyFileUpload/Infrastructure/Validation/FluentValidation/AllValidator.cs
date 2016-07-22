namespace NancyFileUpload.Infrastructure.Validation.FluentValidation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using global::FluentValidation.Validators;

    public class AllValidator<TProperty> : PropertyValidator
    {
        private readonly Func<TProperty, bool> predicate;

        public AllValidator(Func<TProperty, bool> predicate, string message)
            : base(message)
        {
            this.predicate = predicate;
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            var list = context.PropertyValue as IEnumerable<TProperty>;

            if (list == null)
            {
                return false;
            }

            return list.All(predicate);
        }
    }
}