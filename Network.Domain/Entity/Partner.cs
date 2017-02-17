using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Domain.Entity
{
    public class Partner : BaseEntity
    {
        [Key]
        public Guid PartnerId { get; set; }
        [MaxLength(50)]
        public string PartnerName { get; set; }
        [MaxLength(50)]
        public string PartnerPhone { get; set; }
        //có thể chưa có người liên hệ
        [ForeignKey("Person")]
        public Guid? PersonId { get; set; }
        public virtual Person Person { get; set; }
        public ICollection<Contract> Contracts { get; set; }
    }
}
