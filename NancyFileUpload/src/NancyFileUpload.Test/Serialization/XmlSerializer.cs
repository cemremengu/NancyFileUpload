namespace NancyFileUpload.Test.Serialization
{
    using System.Xml.Serialization;
    using Nancy.Testing;

    public class XmlDeserializer : IResultSerializer
    {
        public T Deserialize<T>(BrowserResponse response)
        {
            var serializer = new XmlSerializer(typeof(T));

            return (T) serializer.Deserialize(response.Body.AsStream());
        }
    }
}