
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
            this.FileAttachments = new HashSet<FileAttachment>();
            //default VNĐ
            this.ContractMoneyType = EType.MoneyEnum.VND;
            //default 1 active, 0 inactive
            this.ContractStatus = EType.StatusEnum.Available;
            //default false not deleted
                       
        }
        [Key]
        public Guid ContractId { get; set; }
        
        public Guid PartnerId { get; set; }
        [ForeignKey("PartnerId")]
        //thông tin đối tác
        public virtual Partner Partner { get; set; }
        //thoi gian cho thue dựa theo ngày hiệu lực và ngày hết hiệu lực
        
        //DocumentId của địa điểm 
        public Guid DocumentId { get; set; }
        [ForeignKey("DocumentId")]
        public virtual Document Document { get; set; }
                
        //tiền đặt cọc
        public float ContractDeposit { get; set; }
        //loại tiền hợp đồng
        public EType.MoneyEnum ContractMoneyType { get; set; }
        //hinh ảnh địa điểm
        
     //   public virtual ICollection<FileAttachment> ContractFiles { get; set; }
        //thời gian hiệu lực hợp đồng
        public DateTime ContractValidDate { get; set; }
        //thời gian hết hiệu lực hợp đồng
        public DateTime? ContractInvalidDate { get; set; }
        //thoi gian hệ thống tạo hợp đồng
       
        //tình trạng hợp đồng
        public EType.StatusEnum ContractStatus { get; set; }
        
        //phương thức thanh toán bao lâu 1 lần
        public short ContractSchedulePayment { get; set; }

        //phương thức hoàn trả mặt bằng
     //   [Index("IntegrityPlanIndex", IsUnique = true)]
        public EType.IntegrityPlanTypeEnum IntegrityPlanType { get; set; }
    //    [ForeignKey("IntegrityPlanId")]
      //  public virtual IntegrityPlan IntegrityPlan { get; set; }
        //ECMId reference 
        public Guid? ECMId { get; set; }
        //ECM reference 
        public virtual ECM ECM { get; set; }

        public virtual ICollection<FileAttachment> FileAttachments { get; set; }
        public virtual ICollection<Cost> Costs { get; set; }
    }
   
}
