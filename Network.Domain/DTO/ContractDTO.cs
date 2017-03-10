using Network.Domain.Entity;
using Network.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Domain.DTO
{
    public class ContractDTO
    {
        public ContractDTO()
        {
            this.ContractMoneyType = EType.MoneyEnum.VND;
            this.ContractFileAttachments = new HashSet<ContractFileAttachment>();
            this.ContractStatus = EType.StatusEnum.Available;

        }

        public Guid ContractId { get; set; }

        public Guid PartnerId { get; set; }
        public string PartnerName { get; set; }
        //  public virtual Partner Partner { get; set; }
        public  Guid LocationId { get; set; }
        public string LocationName { get; set; }
        public string LocationCode { get; set; }
        public string LocationAddress { get; set; }

        public float? LocationAreaM2 { get; set; }
        //  public virtual Location Location { get; set; }
        //Tên hợp đồng 
        public string ContractName { get; set; }
        public string ContractNumber { get; set; }

        //Ngày ký
        public string ContractSignedDate { get; set; }

        
        public string ContractValidDate { get; set; }
        //ngày hết hiệu lực hợp đồng thời gian thuê
        public string ContractInvalidDate { get; set; }


        public float ContractBalance { get; set; }

        public bool ContractIsTax { get; set; }
        
        public short ContractDeposit { get; set; }
        public string ContractFirstPayDate { get; set; }
       
        public EType.MoneyEnum ContractMoneyType { get; set; }
        //ngày hiệu lực hợp đồng thời gian thuê
        

        public EType.StatusEnum ContractStatus { get; set; }

        public EType.SchedulePaymentEnum ContractSchedulePayment { get; set; }

        public EType.IntegrityPlanTypeEnum IntegrityPlanType { get; set; }
        //Conditions of the contract term ends before
        public short ContractConditionTermEnd { get; set; }
        //Conditions of contract extension
        public short ContractConditionExtension { get; set; }
        public virtual ICollection<ContractFileAttachment> ContractFileAttachments { get; set; }
    }
}
