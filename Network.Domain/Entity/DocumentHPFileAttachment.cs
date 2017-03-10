using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Domain.Entity
{
    public class DocumentHPFileAttachment :BaseEntity
    {
        [Key, ForeignKey("DocumentHP"), Column(Order = 1)]
        public Guid DocumentHPId { get; set; }
        [Key, ForeignKey("FileAttachment"), Column(Order = 0)]
        public Guid FileAttachmentId { get; set; }
        public string FileAttachmentGroup { get; set; }
        [MaxLength(200)]
        public string FileAttachmentName { get; set; }

        public virtual DocumentHP DocumentHP { get; set; }
        public virtual FileAttachment FileAttachment { get; set; }
    }
}
