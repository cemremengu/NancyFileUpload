namespace NancyFileUpload.Test.Handlers
{
    using System.IO;
    using System.Text;
    using Nancy;
    using NancyFileUpload.Handlers;
    using NancyFileUpload.Infrastructure.Settings;
    using Rhino.Mocks;
    using Utilities;
    using Xunit;

    public class LocalStorageUploadHandlerTest : FileSupportingTestBase
    {
        public LocalStorageUploadHandlerTest()
        {
            applicationSettingsMock = MockRepository.Mock<IApplicationSettings>();
            rootPathProviderMock = MockRepository.Mock<IRootPathProvider>();

            handler = new LocalStorageUploadHandler(applicationSettingsMock, rootPathProviderMock);
        }

        private readonly IApplicationSettings applicationSettingsMock;
        private readonly IRootPathProvider rootPathProviderMock;

        private readonly LocalStorageUploadHandler handler;

        [Fact]
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

            Assert.Equal(true, Create(fileName, fileContent.ToString()));

            using (var fileReader = new FileStream(GetAbsolutePath(fileName), FileMode.Open))
            {
                var fileUploadResult = handler.HandleUpload(fileName, fileReader).Result;

                Assert.Equal(true, Exists(fileUploadResult.Identifier));
                Assert.Equal(true, Delete(fileUploadResult.Identifier));
            }

            Assert.Equal(true, Delete(fileName));
        }
    }
}