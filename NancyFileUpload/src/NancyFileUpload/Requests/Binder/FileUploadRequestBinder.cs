namespace NancyFileUpload.Requests.Binder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Nancy;
    using Nancy.ModelBinding;

    public class FileUploadRequestBinder : IModelBinder
    {
        public object Bind(NancyContext context, Type modelType, object instance, BindingConfig configuration,
            params string[] blackList)
        {
            var fileUploadRequest = instance as FileUploadRequest ?? new FileUploadRequest();

            var form = context.Request.Form;

            fileUploadRequest.Tags = GetTags(form["tags"]);
            fileUploadRequest.Title = form["title"];
            fileUploadRequest.Description = form["description"];
            fileUploadRequest.File = GetFileByKey(context, "file");
            fileUploadRequest.ContentSize = GetContentSize(context);

            return fileUploadRequest;
        }

        public bool CanBind(Type modelType)
        {
            return modelType == typeof(FileUploadRequest);
        }

        private IList<string> GetTags(dynamic field)
        {
            try
            {
                var tags = (string) field;
                return tags.Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries);
            }
            catch
            {
                return new List<string>();
            }
        }

        private HttpFile GetFileByKey(NancyContext context, string key)
        {
            var files = context.Request.Files;
            return files?.FirstOrDefault(x => x.Key == key);
        }

        private long GetContentSize(NancyContext context)
        {
            return context.Request.Headers.ContentLength;
        }
    }
}