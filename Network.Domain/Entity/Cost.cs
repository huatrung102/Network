using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Domain.Entity
{
    public class Cost : BaseEntity
    {
        public Cost()
        {
            this.CostOther = 0;
            this.CostTax = 0;
            this.CostBalance = 0;
        }
       
        [Key, ForeignKey("Contract"),Column(Order = 1)]
        public Guid ContractId { get; set; }
        [Key, Column(Order = 0)]        
        public Guid CostId { get; set; }
        public int CostOfMonth { get; set; }
        public float CostValue { get; set; }

        public float? CostExchangeRate { get; set; }

       
        public virtual Contract Contract { get; set; }
        public float? CostOther { get; set; }
        public float? CostTax { get; set; }
        public float? CostBalance { get; set; }
    }

   
}
