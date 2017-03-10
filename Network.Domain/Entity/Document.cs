using Network.Common.DefineAttribute;
using Network.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Network.Domain.Entity
{
    //Hồ sơ pháp lý của địa điểm
    public class Document : BaseEntity//, IObjectWithState
    {
        public Document()
        {
            this.DocumentFileAttachments = new HashSet<DocumentFileAttachment>();
        }

        [Key, Column(Order = 0)]
        public Guid DocumentId { get; set; }
        [ForeignKey("Location")]
        public Guid LocationId { get; set; }
        public virtual Location Location { get; set; }
        [Required]
        [MaxLength(25)]
        public string DocumentNumber { get; set; }

        [MaxLength(200)]
        public string DocumentDescription { get; set; }

        //danh sách hợp đồng đi kèm theo bộ hồ sơ
        //               public virtual ICollection<Contract> Contracts { get; set; }
        [ScriptIgnore]
        public virtual ICollection<DocumentFileAttachment> DocumentFileAttachments { get; set; }
        [NotMapped]
        public EType.State State { get; set; }
       
    }
}
