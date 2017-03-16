using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Common.Extensions
{
    public class NWException : Exception
    {
        public int ErrorCode { get; set; }

        public NWException(string message) : base(message)
        {
            this.ErrorCode = ResponseConstants.ERROR_SYSTEM;
        }

        public NWException(string message,int errorCode) : base(message)
        {
            this.ErrorCode = errorCode;
        }
    }
}
