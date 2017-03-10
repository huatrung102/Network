
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
    public class Contract :BaseEntity
    {
        public Contract()
        {
            this.ContractFileAttachments = new HashSet<ContractFileAttachment>();
            //default VNĐ
            this.ContractMoneyType = EType.MoneyEnum.VND;
            //default 1 active, 0 inactive
            this.ContractStatus = EType.StatusEnum.Available;
            //default false not deleted
            this.Costs = new HashSet<Cost>();
            //default là 1 tháng
            this.ContractSchedulePayment = EType.SchedulePaymentEnum.Monthly;
        }
        [Key]
        public Guid ContractId { get; set; }
        
        public Guid PartnerId { get; set; }
        [ForeignKey("PartnerId")]
        //thông tin đối tác
        public virtual Partner Partner { get; set; }
        //Tên hợp đồng 
        public string ContractName { get; set; }

        public string ContractNumber { get; set; }
        //hợp đồng theo địa điểm 
        public Guid LocationId { get; set; }
        [ForeignKey("LocationId")]
        public virtual Location Location { get; set; }
                
        //số tháng đặt cọc (theo tiền thuê * 
        public short ContractDeposit { get; set; }
        //loại tiền hợp đồng
        public EType.MoneyEnum ContractMoneyType { get; set; }
        //so tien thue tren hop dong
        public float ContractBalance { get; set; }

        public bool ContractIsTax { get; set; }
       
        //thời gian hiệu lực giá thuê hợp đồng
        public DateTime ContractValidDate { get; set; }
        //thời gian hết hiệu lực giá thuê hợp đồng
        public DateTime? ContractInvalidDate { get; set; }
        // kỳ thanh toán đầu tiên
        public DateTime? ContractFirstPayDate { get; set; }
        //Ngày ký
        public DateTime ContractSignedDate { get; set; }
        //tình trạng hợp đồng
        public EType.StatusEnum ContractStatus { get; set; }
        
        //phương thức thanh toán bao lâu 1 lần
        public EType.SchedulePaymentEnum ContractSchedulePayment { get; set; }

        //phương thức hoàn trả mặt bằng
     //   [Index("IntegrityPlanIndex", IsUnique = true)]
        public EType.IntegrityPlanTypeEnum IntegrityPlanType { get; set; }
        //Conditions of the contract term ends before
        public short ContractConditionTermEnd { get; set; }
        //Conditions of contract extension
        public short ContractConditionExtension { get; set; }
        
        //ECMId reference 
        public Guid? ECMId { get; set; }
        //ECM reference 
        public virtual ECM ECM { get; set; }

        public virtual ICollection<ContractFileAttachment> ContractFileAttachments { get; set; }
        public virtual ICollection<Cost> Costs { get; set; }
    }
   
}
