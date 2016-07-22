namespace NancyFileUpload.Test.Serialization
{
    using System.IO;
    using Nancy.Testing;
    using Newtonsoft.Json;

    public class JsonSerializer : IResultSerializer
    {
        public T Deserialize<T>(BrowserResponse response)
        {
            using (var reader = new StreamReader(response.Body.AsStream()))
            {
                return JsonConvert.DeserializeObject<T>(reader.ReadToEnd());
            }
        }
    }
}