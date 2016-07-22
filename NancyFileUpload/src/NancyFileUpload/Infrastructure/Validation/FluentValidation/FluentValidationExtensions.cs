namespace NancyFileUpload.Infrastructure.Validation.FluentValidation
{
    using System;
    using System.Collections.Generic;
    using global::FluentValidation;

    public static class FluentValidationExtensions
    {
        public static IRuleBuilderOptions<T, IList<TProperty>> LengthBetweenInclusiveBounds<T, TProperty>(
            this IRuleBuilder<T, IList<TProperty>> ruleBuilder, int min, int max)
        {
            return ruleBuilder.SetValidator(new LenthBetweenInclusiveBoundsValidator<TProperty>(min, max));
        }

        public static IRuleBuilderOptions<T, IList<TProperty>> All<T, TProperty>(
            this IRuleBuilder<T, IList<TProperty>> ruleBuilder, Func<TProperty, bool> predicate, string message)
            where TProperty : class
        {
            return ruleBuilder.SetValidator(new AllValidator<TProperty>(predicate, message));
        }
    }
}