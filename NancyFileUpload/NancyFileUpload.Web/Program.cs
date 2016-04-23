// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Nancy.Hosting.Self;
using System;

namespace NancyFileUpload.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var endpoint = "http://localhost:1234";
            using (var host = new NancyHost(new Uri(endpoint)))
            {
                host.Start();

                Console.WriteLine("Server started on {0}...", endpoint);
                Console.ReadLine();
            }
        }
    }
}