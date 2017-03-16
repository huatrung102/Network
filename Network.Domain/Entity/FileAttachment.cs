using Network.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Network.Domain.Entity
{
    public class FileAttachment : BaseEntity
    {
        public FileAttachment()
        {
            this.ContractFileAttachments = new HashSet<ContractFileAttachment>();
            this.DocumentFileAttachments = new HashSet<DocumentFileAttachment>();
            this.LocationFileAttachments = new HashSet<LocationFileAttachment>();
            
            this.LocationHPFileAttachments = new HashSet<LocationHPFileAttachment>();
            this.DocumentHPFileAttachments = new HashSet<DocumentHPFileAttachment>();
        } 
        
        public  byte[] Content { get; set; }
        [Key]
        public Guid FileAttachmentId { get; set; }
        [ScriptIgnore]
        public virtual ICollection<ContractFileAttachment> ContractFileAttachments { get; set; }
        [ScriptIgnore]
        public virtual ICollection<DocumentFileAttachment> DocumentFileAttachments { get; set; }
        [ScriptIgnore]
        public virtual ICollection<LocationFileAttachment> LocationFileAttachments { get; set; }
        [ScriptIgnore]
        public virtual ICollection<LocationHPFileAttachment> LocationHPFileAttachments { get; set; }
        [ScriptIgnore]
        public virtual ICollection<DocumentHPFileAttachment> DocumentHPFileAttachments { get; set; }
        

        //     public Guid RefFileAttachmentId { get; set; }

        //    public virtual Guid ContractId { get; set; }
        //    public virtual Guid LocationId { get; set; }
    }
}
