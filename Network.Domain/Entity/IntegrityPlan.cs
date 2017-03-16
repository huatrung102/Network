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
    //định nghĩa hiện trạng mặt bằng -  not use
    public class IntegrityPlan : BaseEntity
    {
        public IntegrityPlan()
        {
            this.IntegrityPlanFileAttachments = new HashSet<FileAttachment>();
        }
        [Key]
        public Guid IntegrityPlanId { get; set; }
        //contract id
       // [ForeignKey("Contract")]
    //    public Guid ContractId { get; set; }
        // định nghĩa loại hiện trạng mặt bằng
        public EType.IntegrityPlanTypeEnum IntegrityPlanType { get; set; }
        //hiện trạng được định nghĩa trong hợp đồng nào
     //   public virtual Contract Contract { get; set; }
        //ghi chú về hiện trạng
        [MaxLength(300)]
        public string IntegrityPlanDescription { get; set; }
        //có thể đính kèm hình ảnh về hiện trạng
        public virtual ICollection<FileAttachment> IntegrityPlanFileAttachments { get; set; }
    }
}
