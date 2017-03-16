using Network.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Domain.Entity
{
    //partner nhà dự án
    public class PartnerHP :BaseEntity
    {
        public PartnerHP()
        {
            this.Contracts = new HashSet<Contract>();
            this.DocumentPartnerHPs = new HashSet<DocumentPartnerHP>();
        }
        [Key]
        public Guid PartnerHPId { get; set; }
        [MaxLength(50)]

        public string PartnerHPName { get; set; }
        [MaxLength(50)]
        public string PartnerHPPhone { get; set; }
               

        public Guid PersonId { get; set; }
        [ForeignKey("PersonId")]
        public virtual Person PartnerHPPerson { get; set; }

       
        public ICollection<Contract> Contracts { get; set; }
        public ICollection<DocumentPartnerHP> DocumentPartnerHPs { get; set; }
    }
}
