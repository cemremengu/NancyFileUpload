// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Nancy.Testing;
using System.Xml.Serialization;

namespace NancyFileUpload.Test.Serialization
{
    public class XmlDeserializer : IResultSerializer
    {
        public T Deserialize<T>(BrowserResponse response)
        {
            var serializer = new XmlSerializer(typeof(T));

            return (T)serializer.Deserialize(response.Body.AsStream());
        }
    }
}
