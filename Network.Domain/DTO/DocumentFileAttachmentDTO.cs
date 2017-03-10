using Network.Common.Helper;
using Network.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Domain.DTO
{
    public class DocumentFileAttachmentDTO
    {
        public DocumentFileAttachmentDTO()
        {
            this.FileAttachmentId = Guid.NewGuid();
        }
        
        public Guid DocumentId { get; set; }
        public EType.DocumentTypeEnum DocumentType { get; set; }
        public Guid FileAttachmentId { get; set; }
        public byte[] Content { get; set; }
        public string FileName { get; set; }
        public bool IsLocalFileName { get; set; }
        public string FileDescription { get; set; }
        public string FileAttachmentValidDate { get; set; }

        public bool FileAttachmentStatus { get; set; }

        // public EType.FileGroupType FileAttachmenGroup { get; set; }
    }
}
