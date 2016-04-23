
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NancyFileUpload.Infrastructure.Errors.Enums;

namespace NancyFileUpload.Infrastructure.Errors.Model
{
    /// <summary>
    /// This class need to be this weird, due to limitations with the Microsoft XML Serializer,
    /// that is used by the framework. We are providing a default constructor and public getter
    /// and setters.
    /// </summary>
    public class ServiceErrorModel
    {
        public ServiceErrorModel() { }

        public ServiceErrorModel(ServiceErrorEnum code, string details)
        {
            Code = code;
            Details = details;
        }
        
        public ServiceErrorEnum Code { get; set; }

        public string Details { get; set; }
    }
}
