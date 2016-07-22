namespace NancyFileUpload.Test.Infrastructure.Domain
{
    using System;
    using NancyFileUpload.Infrastructure.Domain;
    using Xunit;

    public class FileSizeTest
    {
        [Fact]
        public void BytesCorrect_When_Converting_Between_Units()
        {
            Assert.Equal(2, FileSize.Create(2, FileSize.Unit.Byte).Get(FileSize.Unit.Byte));
            Assert.Equal((long) (2*Math.Pow(2, 10)), FileSize.Create(2, FileSize.Unit.Kilobyte).Get(FileSize.Unit.Byte));
            Assert.Equal((long) (1000*Math.Pow(2, 20)),
                FileSize.Create(1000, FileSize.Unit.Megabyte).Get(FileSize.Unit.Byte));
            Assert.Equal((long) (2*Math.Pow(2, 30)), FileSize.Create(2, FileSize.Unit.Gigabyte).Get(FileSize.Unit.Byte));
            Assert.Equal((long) (3*Math.Pow(2, 40)), FileSize.Create(3, FileSize.Unit.Terabyte).Get(FileSize.Unit.Byte));
        }
    }
}