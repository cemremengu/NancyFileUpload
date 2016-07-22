namespace NancyFileUpload.Test.Utilities
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Text;
    using log4net;

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
            var filePath = GetAbsolutePath(fileName);
            try
            {
                File.WriteAllText(filePath, fileContent, Encoding.UTF8);

                return true;
            }
            catch (Exception e)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error($"Could not create {filePath}", e);
                }
                return false;
            }
        }

        protected bool Delete(string fileName)
        {
            var filePath = GetAbsolutePath(fileName);
            try
            {
                File.Delete(filePath);

                return true;
            }
            catch (Exception e)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error($"Could not delete {filePath}", e);
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