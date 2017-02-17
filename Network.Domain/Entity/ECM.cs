using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Domain.Entity
{
    public class ECM : BaseEntity
    {
        [Key]
        public Guid ECMId { get; set; }
        public string ECMLink { get; set; }
        public string ECMName { get; set; }
        public short ECMStatus { get; set; }

     //   public Guid ContractId { get; set; }
   //     [ForeignKey("ContractId")]
   //     public virtual Contract Contract { get; set; }

    }
}
