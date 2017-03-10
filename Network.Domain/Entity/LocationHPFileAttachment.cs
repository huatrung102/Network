using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Domain.Entity
{
    public class LocationHPFileAttachment : BaseEntity
    {
        [Key, ForeignKey("LocationHP"), Column(Order = 1)]
        public Guid LocationHPId { get; set; }
        [Key, ForeignKey("FileAttachment"), Column(Order = 0)]
        public Guid FileAttachmentId { get; set; }
        public string FileAttachmentGroup { get; set; }

        public virtual LocationHP LocationHP { get; set; }
        public virtual FileAttachment FileAttachment { get; set; }
    }
}
