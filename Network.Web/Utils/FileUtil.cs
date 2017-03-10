using Network.Common.Helper;
using Network.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Network.Web.Utils
{
    public class FileUtil
    {
        public static FileAttachment CreateFileFromRequest(HttpPostedFileBase file)
        {
            return new FileAttachment()
            {

                Content = FileHelper.readAllBytes(file),
                FileAttachmentId = Guid.NewGuid()

            };

        }
    }
}