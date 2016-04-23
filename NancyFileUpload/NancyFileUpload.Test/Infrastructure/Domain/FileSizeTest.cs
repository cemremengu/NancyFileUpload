// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NancyFileUpload.Infrastructure.Domain;
using NUnit.Framework;
using System;

using Unit = NancyFileUpload.Infrastructure.Domain.FileSize.Unit;

namespace NancyFileUpload.Test.Infrastructure.Domain
{
    [TestFixture]
    public class FileSizeTest
    {
        [Test]
        public void BytesCorrect_When_Converting_Between_Units()
        {
            Assert.AreEqual(2, FileSize.Create(2, Unit.Byte).Get(Unit.Byte));
            Assert.AreEqual((long) (2 * Math.Pow(2, 10)), FileSize.Create(2, Unit.Kilobyte).Get(Unit.Byte));
            Assert.AreEqual((long) (1000 * Math.Pow(2, 20)), FileSize.Create(1000, Unit.Megabyte).Get(Unit.Byte));
            Assert.AreEqual((long) (2 * Math.Pow(2, 30)), FileSize.Create(2, Unit.Gigabyte).Get(Unit.Byte));
            Assert.AreEqual((long) (3 * Math.Pow(2, 40)), FileSize.Create(3, Unit.Terabyte).Get(Unit.Byte));
        }
    }
}
