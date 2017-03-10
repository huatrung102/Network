using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Common.Helper
{
    public class GuidHelper
    {
        private static readonly string zeroGuid = "00000000-0000-0000-0000-000000000000";
        public static Guid ConvertStrToGuid(string guid)
        {
            try
            {
                string temp = MvcHelper.DeserializeObject<string>(guid);
                return new Guid(temp);
            }
            catch (Exception) { }
           
            return new Guid(zeroGuid);
        }

        public static Guid CheckAndRefreshGuid(string guid) 
            => zeroGuid.Equals(guid) ? Guid.NewGuid() : new Guid(guid);

    }
}
