namespace NancyFileUpload.Infrastructure.Validation.FluentValidation
{
    using System.Collections.Generic;
    using System.Linq;
    using global::FluentValidation.Validators;

    public class LenthBetweenInclusiveBoundsValidator<TProperty> : PropertyValidator
    {
        private readonly int max;
        private readonly int min;

        public LenthBetweenInclusiveBoundsValidator(int min, int max)
            : base(string.Format("Length of the array is not between {0} and {1}.", min, max))
        {
            this.min = min;
            this.max = max;
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            var list = context.PropertyValue as IList<TProperty>;

            if (list == null)
            {
                return false;
            }

            if (list.Count() < min || list.Count() > max)
            {
                return false;
            }

            return true;
        }
    }
}