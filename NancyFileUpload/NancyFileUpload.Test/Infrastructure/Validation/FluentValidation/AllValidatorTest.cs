// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using FluentValidation;
using NUnit.Framework;
using System.Collections.Generic;
using NancyFileUpload.Infrastructure.Validation.FluentValidation;

namespace NancyFileUpload.Test.Infrastructure.Validation.FluentValidation
{
    [TestFixture]
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

        [Test]
        public void No_ValidationError_When_Less_Than_5_Characters() 
        {
            var validator = new EntityValidator();

            var entity = new Entity()
            {
                Values = new[] { "1234", "123", "1252"}
            };

            var result = validator.Validate(entity);

            Assert.AreEqual(true, result.IsValid);
        }

        [Test]
        public void ValidationError_When_More_Than_Or_Equal_5_Characters()
        {
            var validator = new EntityValidator();

            var entity = new Entity()
            {
                Values = new[] { "1234", "12345", "1252" }
            };

            var result = validator.Validate(entity);

            Assert.AreEqual(false, result.IsValid);
        }


    }
}
