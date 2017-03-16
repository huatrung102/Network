using Network.Domain.Entity;
using Network.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Domain.DTO
{
    public class PartnerDTO
    {
        public Guid PartnerId { get; set; }       

        public string PartnerName { get; set; }
        
        public string PartnerPhone { get; set; }
        //loại cá nhân hay công ty
        public EType.PartnerTypeEnum PartnerType { get; set; }
        public Guid? PersonId { get; set; }
        public string PartnerPersonName { get; set; }
        
        public string PartnerPersonPhone { get; set; }
        
        public string PersonPosition { get; set; }
        public string PartnerRepresentation { get; set; }

        public string PartnerPersonAddress { get; set; }
        //   public virtual ICollection<Partner> Partners { get; set; }

    }
}
