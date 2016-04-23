// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Nancy;
using Nancy.Testing;
using NancyFileUpload.Infrastructure.Errors.Enums;
using NancyFileUpload.Infrastructure.Errors.Model;
using NancyFileUpload.Test.Serialization;
using NancyFileUpload.Web;
using NUnit.Framework;

namespace NancyFileUpload.Test.Modules
{
    [TestFixture]
    public class FileUploadModuleTest
    {
        [Test]
        public void Should_Return_Validation_Error_When_Invalid_Data_Given()
        {
            var browser = new Browser(new Bootstrapper());

            // When
            var result = browser.Post("/file/upload", with =>
            {
                with.Header("Accept", "application/json");
                with.HttpRequest();
            });

            // A Validation Error is handled as a Bad request:
            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);

            // Deserialize the Error:
            var error = new JsonSerializer().Deserialize<ServiceErrorModel>(result);

            Assert.AreEqual(ServiceErrorEnum.ValidationError, error.Code);
            Assert.AreEqual("Validation failed. Properties: (Title, Tags, File)", error.Details);
        }
    }
}