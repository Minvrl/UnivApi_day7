using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Univ.Service.Exceptions
{
    public class RestException:Exception
    {
        public int Code { get; set; }
        public string? Message { get; set; }
        public List<RestExceptionError> Errors { get; set; } = new List<RestExceptionError>();
        public RestException() { }
        public RestException(int code,string message)
        {

            this.Code = code;
            this.Message = message;
        }
        public RestException(int code,string errorKey,string errorMsg,string? msg = null)
        {
            this.Code =code;    
            this.Message = msg;
            this.Errors = new List<RestExceptionError> { new RestExceptionError(errorKey,errorMsg)};

        }
    }
    public class RestExceptionError 
    {
        public string Key { get; set; }
        public string Message { get; set; }
        public RestExceptionError()
        {
            
        }
        public RestExceptionError(string key,string msg)
        {
            this.Key = key;
            this.Message = msg;
        }
    }

}
