using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Common.Extensions
{
    public class JsonError
    {
        public string Message { get; set; }
        public int Code { get; set; }

        public JsonError(string message, int code)
        {
            this.Message = message;
            this.Code = code;
        }
    }
}
