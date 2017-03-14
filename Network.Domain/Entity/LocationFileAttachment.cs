using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Domain.Entity
{
    public class LocationFileAttachment :BaseEntity
    {
        [Key, ForeignKey("Location"), Column(Order = 1)]
        public Guid LocationId { get; set; }
        [Key, ForeignKey("FileAttachment"), Column(Order = 0)]
        public Guid FileAttachmentId { get; set; }
       

        public virtual Location Location { get; set; }
        public virtual FileAttachment FileAttachment { get; set; }
    }
}
