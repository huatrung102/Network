using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Network.Common.Helper
{
    public class FileHelper
    {
        public static byte[] readAllBytes(HttpPostedFileBase s)
        {
            byte[] result = null;
            using (var reader = new System.IO.BinaryReader(s.InputStream))
            {
                result = reader.ReadBytes(s.ContentLength);
            }
            return result;
        }
    }
}
