using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NancyFileUpload.Test.Utilities
{
    [TestFixture]
    public abstract class FileSupportingTestBase
    {
        protected string GetAbsolutePath(string fileName)
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory;

            return Path.Combine(basePath, fileName);
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
                return false;
            }
        }

        protected bool Delete(string fileName)
        {
            try
            {
                File.Delete(GetAbsolutePath(fileName));

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        protected bool Exists(string fileName)
        {
            return File.Exists(GetAbsolutePath(fileName));
        }
    }
}
