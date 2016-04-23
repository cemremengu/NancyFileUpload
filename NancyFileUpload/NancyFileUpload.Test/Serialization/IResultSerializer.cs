// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Nancy.Testing;

namespace NancyFileUpload.Test.Serialization
{
    public interface IResultSerializer
    {
        T Deserialize<T>(BrowserResponse response);
    }
}
