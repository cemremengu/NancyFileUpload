namespace NancyFileUpload.Test.Infrastructure.Validation.FluentValidation
{
    using System.Collections.Generic;
    using global::FluentValidation;
    using NancyFileUpload.Infrastructure.Validation.FluentValidation;
    using Xunit;

    public class LengthInclusiveBoundsValidatorTest
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
                    .LengthBetweenInclusiveBounds(1, 4);
            }
        }

        [Fact]
        public void No_ValidationError_When_Inclusive_Bounds()
        {
            var validator = new EntityValidator();

            var entityLeftBound = new Entity
            {
                Values = new[] {"1234"}
            };

            var entityRightBound = new Entity
            {
                Values = new[] {"1234", "123", "1252", "124323"}
            };


            Assert.Equal(true, validator.Validate(entityLeftBound).IsValid);
            Assert.Equal(true, validator.Validate(entityRightBound).IsValid);
        }

        [Fact]
        public void ValidationError_When_Null()
        {
            var validator = new EntityValidator();

            var entityNull = new Entity
            {
                Values = null
            };

            Assert.Equal(false, validator.Validate(entityNull).IsValid);
        }

        [Fact]
        public void ValidationError_When_Outside_Bounds()
        {
            var validator = new EntityValidator();

            var entityOutsideRightBound = new Entity
            {
                Values = new[] {"1234", "12345", "1252", "1234", "4534"}
            };

            var entityOutsideLeftBound = new Entity
            {
                Values = new List<string>()
            };

            Assert.Equal(false, validator.Validate(entityOutsideLeftBound).IsValid);
            Assert.Equal(false, validator.Validate(entityOutsideRightBound).IsValid);
        }
    }
}