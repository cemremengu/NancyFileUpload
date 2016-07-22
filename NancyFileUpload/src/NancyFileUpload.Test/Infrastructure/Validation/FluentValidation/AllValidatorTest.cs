namespace NancyFileUpload.Test.Infrastructure.Validation.FluentValidation
{
    using System.Collections.Generic;
    using global::FluentValidation;
    using NancyFileUpload.Infrastructure.Validation.FluentValidation;
    using Xunit;

    public class AllValidatorTest
    {
        private class Entity
        {
            public IList<string> Values { get; set; }
        }

        private class EntityValidator : AbstractValidator<Entity>
        {
            public EntityValidator()
            {
                RuleFor(x => x.Values)
                    .All(x => x.Length < 5, "Error");
            }
        }

        [Fact]
        public void No_ValidationError_When_Less_Than_5_Characters()
        {
            var validator = new EntityValidator();

            var entity = new Entity
            {
                Values = new[] {"1234", "123", "1252"}
            };

            var result = validator.Validate(entity);

            Assert.Equal(true, result.IsValid);
        }

        [Fact]
        public void ValidationError_When_More_Than_Or_Equal_5_Characters()
        {
            var validator = new EntityValidator();

            var entity = new Entity
            {
                Values = new[] {"1234", "12345", "1252"}
            };

            var result = validator.Validate(entity);

            Assert.Equal(false, result.IsValid);
        }
    }
}