using Network.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Domain.Entity
{
    public class FileAttachment : BaseEntity
    {
        
        [MaxLength(200)]
        public  string FileAttachmentName { get; set; }

        public EType.FileGroupType FileAttachmenGroup { get; set; }
        public  byte[] Content { get; set; }
        [Key]
        public Guid FileAttachmentId { get; set; }

   //     public Guid RefFileAttachmentId { get; set; }

        //    public virtual Guid ContractId { get; set; }
        //    public virtual Guid LocationId { get; set; }
    }
}
