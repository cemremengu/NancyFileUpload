using NancyFileUpload.Infrastructure.Domain;
using NancyFileUpload.Infrastructure.Settings;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NancyFileUpload.Test.Infrastructure.Settings
{
    [TestFixture]
    public class ApplicationSettingsTest
    {
        [Test]
        public void Constructor_Throws_When_Required_Parameter_Is_Null()
        {
            string uploadDirectory = "upload_dir";
            FileSize fileSize = FileSize.Create(321, FileSize.Unit.Kilobyte);

            Assert.Throws<ArgumentNullException>(() => new ApplicationSettings(uploadDirectory, null));
            Assert.Throws<ArgumentNullException>(() => new ApplicationSettings(null, fileSize));
            Assert.Throws<ArgumentNullException>(() => new ApplicationSettings(null, null));

            Assert.DoesNotThrow(() => new ApplicationSettings(uploadDirectory, fileSize));
        }

        [Test]
        public void Parameters_Mapped_Correctly_When_Parameters_Are_Given()
        {

            string uploadDirectory = "upload_dir";
            FileSize fileSize = FileSize.Create(321, FileSize.Unit.Kilobyte);

            ApplicationSettings applicationSettings = new ApplicationSettings(uploadDirectory, fileSize);

            Assert.AreEqual(uploadDirectory, applicationSettings.FileUploadDirectory);
            Assert.AreEqual(321, (int)applicationSettings.MaxFileSizeForUpload.Get(FileSize.Unit.Kilobyte));
        }
    }
}
