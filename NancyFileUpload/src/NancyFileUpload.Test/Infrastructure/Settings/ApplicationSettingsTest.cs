namespace NancyFileUpload.Test.Infrastructure.Settings
{
    using System;
    using NancyFileUpload.Infrastructure.Domain;
    using NancyFileUpload.Infrastructure.Settings;
    using Xunit;

    public class ApplicationSettingsTest
    {
        [Fact]
        public void Constructor_Throws_When_Required_Parameter_Is_Null()
        {
            var uploadDirectory = "upload_dir";
            var fileSize = FileSize.Create(321, FileSize.Unit.Kilobyte);

            Assert.Throws<ArgumentNullException>(() => new ApplicationSettings(uploadDirectory, null));
            Assert.Throws<ArgumentNullException>(() => new ApplicationSettings(null, fileSize));
            Assert.Throws<ArgumentNullException>(() => new ApplicationSettings(null, null));

            Assert.Null(Record.Exception(() => new ApplicationSettings(uploadDirectory, fileSize)));
        }

        [Fact]
        public void Parameters_Mapped_Correctly_When_Parameters_Are_Given()
        {
            var uploadDirectory = "upload_dir";
            var fileSize = FileSize.Create(321, FileSize.Unit.Kilobyte);

            var applicationSettings = new ApplicationSettings(uploadDirectory, fileSize);

            Assert.Equal(uploadDirectory, applicationSettings.FileUploadDirectory);
            Assert.Equal(321, (int) applicationSettings.MaxFileSizeForUpload.Get(FileSize.Unit.Kilobyte));
        }
    }
}