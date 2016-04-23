// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using FluentValidation;
using NUnit.Framework;
using System.Collections.Generic;
using NancyFileUpload.Infrastructure.Validation.FluentValidation;

namespace NancyFileUpload.Test.Infrastructure.Validation.FluentValidation
{
    [TestFixture]
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

        [Test]
        public void No_ValidationError_When_Inclusive_Bounds()
        {
            var validator = new EntityValidator();

            var entityLeftBound = new Entity()
            {
                Values = new[] { "1234" }
            };

            var entityRightBound = new Entity()
            {
                Values = new[] { "1234", "123", "1252", "124323" }
            };

            
            Assert.AreEqual(true, validator.Validate(entityLeftBound).IsValid);
            Assert.AreEqual(true, validator.Validate(entityRightBound).IsValid);
        }

        [Test]
        public void ValidationError_When_Outside_Bounds()
        {
            var validator = new EntityValidator();

            var entityOutsideRightBound = new Entity()
            {
                Values = new[] { "1234", "12345", "1252", "1234", "4534" }
            };

            var entityOutsideLeftBound = new Entity()
            {
                Values = new List<string>()
            };

            Assert.AreEqual(false, validator.Validate(entityOutsideLeftBound).IsValid);
            Assert.AreEqual(false, validator.Validate(entityOutsideRightBound).IsValid);
        }

        [Test]
        public void ValidationError_When_Null()
        {
            var validator = new EntityValidator();

            var entityNull = new Entity()
            {
                Values = null
            };

            Assert.AreEqual(false, validator.Validate(entityNull).IsValid);
        }
    }
}
