namespace NancyFileUpload.Requests
{
    using System.Collections.Generic;
    using Nancy;

    public class FileUploadRequest
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public IList<string> Tags { get; set; }

        public long ContentSize { get; set; }

        public HttpFile File { get; set; }
    }
}