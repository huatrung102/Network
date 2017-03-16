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

        [Key, Column(Order = 0)]
        public Guid CostId { get; set; }
        [Key, ForeignKey("Contract"), Column(Order = 1)]
        public Guid ContractId { get; set; }
       
        //tháng trả tiền thuê - use for easy to compute
        public short CostOfMonth { get; set; }
        
        //năm trả tiền thuê- use for easy to compute
        public short CostOfYear { get; set; }

        //số tiền thuê nguyên gốc theo hợp đồng
        public float CostValue { get; set; }
        //tỷ giá hiện tại nếu là khác VNĐ
        public float? CostExchangeRate { get; set; }

        //khác
        public float? CostOther { get; set; }
        //thuế vat
        public float? CostTax { get; set; }
        //số tiền thực trả(đã tính toán)
        public float? CostBalance { get; set; }

        public virtual Contract Contract { get; set; }
    }

   
}
