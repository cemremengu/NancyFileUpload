// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using log4net;
using NUnit.Framework;
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace NancyFileUpload.Test.Utilities
{
    [TestFixture]
    public abstract class FileSupportingTestBase
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);


        protected string GetBasePath()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }

        protected string GetAbsolutePath(string fileName)
        {
            return Path.Combine(GetBasePath(), fileName);
        }

        protected bool Create(string fileName, string fileContent)
        {
            string filePath = GetAbsolutePath(fileName);
            try
            {
                File.WriteAllText(filePath, fileContent, Encoding.UTF8);

                return true;
            }
            catch (Exception e)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(string.Format("Could not create {0}", filePath), e);
                }
                return false;
            }
        }

        protected bool Delete(string fileName)
        {
            string filePath = GetAbsolutePath(fileName);
            try
            {
                File.Delete(filePath);

                return true;
            }
            catch (Exception e)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(string.Format("Could not delete {0}", filePath), e);
                }
                return false;
            }
        }

        protected bool Exists(string fileName)
        {
            return File.Exists(GetAbsolutePath(fileName));
        }
    }
}
