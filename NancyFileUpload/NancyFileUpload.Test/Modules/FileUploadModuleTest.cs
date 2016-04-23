// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Nancy;
using Nancy.Bootstrapper;
using Nancy.Testing;
using NancyFileUpload.Handlers;
using NancyFileUpload.Infrastructure.Domain;
using NancyFileUpload.Infrastructure.Errors.Enums;
using NancyFileUpload.Infrastructure.Errors.Model;
using NancyFileUpload.Infrastructure.Settings;
using NancyFileUpload.Test.Bootstrapping;
using NancyFileUpload.Test.Serialization;
using NancyFileUpload.Test.Utilities;
using NUnit.Framework;
using Rhino.Mocks;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace NancyFileUpload.Test.Modules
{
    [TestFixture]
    public class FileUploadModuleTest : FileSupportingTestBase
    {
        private Bootstrapper bootstrapper;

        private IApplicationSettings applicationSettingsMock;
        private IFileUploadHandler fileUploadHandlerMock;
        
        [SetUp]
        public void SetUp() 
        {
            applicationSettingsMock = MockRepository.GenerateStrictMock<IApplicationSettings>(); 
            fileUploadHandlerMock = MockRepository.GenerateStrictMock<IFileUploadHandler>();

            bootstrapper = new Bootstrapper(new[] 
            {
                new InstanceRegistration(typeof(IApplicationSettings), applicationSettingsMock),
                new InstanceRegistration(typeof(IFileUploadHandler), fileUploadHandlerMock)
            });
        }

        [Test]
        public void Should_Return_Validation_Error_When_Invalid_Data_Given()
        {
            // Checked in the Request Validation:
            applicationSettingsMock.Expect(x => x.MaxFileSizeForUpload)
                .Repeat.Any()
                .Return(FileSize.Create(2, FileSize.Unit.Megabyte));

            // Pass the Bootstrapper with Mocks into the Testing Browser:
            var browser = new Browser(bootstrapper);

            // Define the When Action:
            var result = browser.Post("/file/upload", with =>
            {
                with.Header("Accept", "application/json");
                with.HttpRequest();
            });

            // Check the Results:
            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);

            // Deserialize the Error:
            var error = new JsonSerializer().Deserialize<ServiceErrorModel>(result);

            Assert.AreEqual(ServiceErrorEnum.ValidationError, error.Code);
            Assert.AreEqual("Validation failed. Properties: (Title, Tags, File)", error.Details);
        }

        [Test]
        public void Should_Store_File_When_Request_Is_Valid()
        {
            // Define the File Name and Content:
            var fileName = "persons.txt";

            var fileContent = new StringBuilder()
                .AppendLine("FirstName;LastName;BirthDate")
                .AppendLine("Philipp;Wagner;1986/05/12")
                .AppendLine("Max;Mustermann;2014/01/01");
            
            // Create the File:
            Assert.AreEqual(true, Create(fileName, fileContent.ToString()));

            // The Result of the Upload (we are not writing to disk actually):
            var fileUploadResult = new FileUploadResult() { Identifier = Guid.NewGuid().ToString()};

            // Checked in the Request Validation:
            applicationSettingsMock.Expect(x => x.MaxFileSizeForUpload)
                .Repeat.Any()
                .Return(FileSize.Create(2, FileSize.Unit.Megabyte));

            // Probably we should also check the Content?
            fileUploadHandlerMock.Expect(x => x.HandleUpload(Arg<string>.Is.Equal(fileName), Arg<Stream>.Is.Anything))
                .Repeat.Once()
                .Return(Task.Delay(100).ContinueWith(x => fileUploadResult));

            // Pass the Bootstrapper with Mocks into the Testing Browser:
            var browser = new Browser(bootstrapper);
            
            using (var textReader = new FileStream(GetAbsolutePath(fileName), FileMode.Open))
            {

                // Define the Multipart Form Data for an upload:
                var multipartFormData = new BrowserContextMultipartFormData(
                    (configuration => 
                    {
                        configuration.AddFile("file", fileName, "text", textReader);

                        configuration.AddFormField("tags", "text", "Hans,Wurst");
                        configuration.AddFormField("description", "text", "Description");
                        configuration.AddFormField("title", "text", "Title");
                    }
                ));

                // Define the When Action:
                var result = browser.Post("/file/upload", with =>
                {
                    with.Header("Accept", "application/json");
                    with.Header("Content-Length", "1234");

                    with.HttpRequest();

                    with.MultiPartFormData(multipartFormData);
                });

                // File Upload was successful:
                Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);

                // We get the Expected Identifier:
                var deserializedResponseContent = new JsonSerializer().Deserialize<FileUploadResult>(result);

                Assert.AreEqual(deserializedResponseContent.Identifier, fileUploadResult.Identifier);
            }


            // Finally delete the Temporary file:
            Assert.AreEqual(true, Delete(fileName));
        }
    }
}