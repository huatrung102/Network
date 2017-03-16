using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Domain.Entity
{
    public class DocumentHP : BaseEntity
    {
        public DocumentHP()
        {
            this.DocumentPartnerHPs = new HashSet<DocumentPartnerHP>();
            this.DocumentHPFileAttachments = new HashSet<DocumentHPFileAttachment>();

        }
        [Key, Column(Order = 0)]
        public Guid DocumentHPId { get; set; }
        [ForeignKey("LocationHP")]
        public Guid LocationHPId { get; set; }
        public virtual LocationHP LocationHP { get; set; }
        [Required]
        [MaxLength(50)]
        public string DocumentHPName { get; set; }

        public ICollection<DocumentPartnerHP> DocumentPartnerHPs { get; set; }
        public ICollection<DocumentHPFileAttachment> DocumentHPFileAttachments { get; set; }


    }
}
