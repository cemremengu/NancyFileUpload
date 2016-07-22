namespace NancyFileUpload.Test.Serialization
{
    using Nancy.Testing;

    public interface IResultSerializer
    {
        T Deserialize<T>(BrowserResponse response);
    }
}