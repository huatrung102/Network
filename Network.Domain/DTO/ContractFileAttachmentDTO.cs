using Network.Domain.Entity;
using Network.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Domain.DTO
{
    public class ContractFileAttachmentDTO
    {
        public ContractFileAttachmentDTO()
        {
            this.FileAttachmentId = Guid.NewGuid();
        }

        public Guid ContractId { get; set; }
        public EType.ContractTypeEnum ContractType { get; set; }
        public Guid FileAttachmentId { get; set; }
        public byte[] Content { get; set; }
        public string FileName { get; set; }
        public bool IsLocalFileName { get; set; }
        public string FileDescription { get; set; }
        public string FileAttachmentValidDate { get; set; }
        public string FileAttachmentInvalidDate { get; set; }
        public bool FileAttachmentStatus { get; set; }
    }
}
