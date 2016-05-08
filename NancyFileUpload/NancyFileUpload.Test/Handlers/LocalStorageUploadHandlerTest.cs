// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Nancy;
using NancyFileUpload.Handlers;
using NancyFileUpload.Infrastructure.Settings;
using NancyFileUpload.Test.Utilities;
using NUnit.Framework;
using Rhino.Mocks;
using System.IO;
using System.Text;

namespace NancyFileUpload.Test.Handlers
{
    [TestFixture]
    public class LocalStorageUploadHandlerTest : FileSupportingTestBase
    {
        private IApplicationSettings applicationSettingsMock;
        private IRootPathProvider rootPathProviderMock;

        private LocalStorageUploadHandler handler;

        [SetUp]
        public void SetUp()
        {
            applicationSettingsMock = MockRepository.GenerateStrictMock<IApplicationSettings>();
            rootPathProviderMock = MockRepository.GenerateStrictMock<IRootPathProvider>();

            handler = new LocalStorageUploadHandler(applicationSettingsMock, rootPathProviderMock);
        }
        
        [Test]
        public void Stores_File_Correctly_When_Correct_Data_Given()
        {
            rootPathProviderMock.Expect(x => x.GetRootPath())
                .Repeat.Once()
                .Return(GetBasePath());

            applicationSettingsMock.Expect(x => x.FileUploadDirectory)
                .Repeat.Once()
                .Return(string.Empty);

            var fileName = "person.txt";
            
            var fileContent = new StringBuilder()
                .AppendLine("FirstName;LastName;BirthDate")
                .AppendLine("Philipp;Wagner;1986/05/12")
                .AppendLine("Max;Mustermann;2014/01/01");

            Assert.AreEqual(true, Create(fileName, fileContent.ToString()));

            using (var fileReader = new FileStream(GetAbsolutePath(fileName), FileMode.Open))
            {
                var fileUploadResult = handler.HandleUpload(fileName, fileReader).Result;

                Assert.AreEqual(true, Exists(fileUploadResult.Identifier));
                Assert.AreEqual(true, Delete(fileUploadResult.Identifier));
            }

            Assert.AreEqual(true, Delete(fileName));
        }

    }
}
