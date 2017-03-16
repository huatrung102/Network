using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Common.Extensions
{
    public class JsonResponse<T> 
    {
        public int ResponseCode { get; set; }
        public JsonError JsonError { get; set; }
        public T Data { get; set; }

        public JsonResponse(int responseCode, JsonError error, T data)
        {
            this.ResponseCode = responseCode;
            this.JsonError = error;
            this.Data = data;
        }
    }
}
