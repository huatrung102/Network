using Network.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Network.Domain.Entity
{
    public class ContractFileAttachment :BaseEntity
    {
        public ContractFileAttachment()
        {
            this.FileAttachmentStatus = true;
        }
        [Key, ForeignKey("Contract"), Column(Order = 1)]
        public Guid ContractId { get; set; }
        [Key, ForeignKey("FileAttachment"), Column(Order = 0)]
        public Guid FileAttachmentId { get; set; }
        [MaxLength(200)]
        public string FileName { get; set; }
        [MaxLength(25)]
        public string FileAttachmentValidDate { get; set; }
        [MaxLength(25)]
        public string FileAttachmentInvalidDate { get; set; }

        public bool FileAttachmentStatus { get; set; }
        public EType.ContractTypeEnum ContractType { get; set; }
        [ScriptIgnore]
        public virtual Contract Contract { get; set; }
        [ScriptIgnore]
        public virtual FileAttachment FileAttachment { get; set; }
    }
}
