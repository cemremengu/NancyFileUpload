// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Nancy.Testing;
using Newtonsoft.Json;
using System.IO;

namespace NancyFileUpload.Test.Serialization
{
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
