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
    public class DocumentFileAttachment : BaseEntity//, IObjectWithState
    {
        public DocumentFileAttachment()
        {
            this.FileAttachmentStatus = true;
        }
        [Key, ForeignKey("Document"), Column(Order = 1)]
        public Guid DocumentId { get; set; }
        [Key, ForeignKey("FileAttachment"), Column(Order = 0)]
        public Guid FileAttachmentId { get; set; }
        [MaxLength(200)]
        public string FileName { get; set; }

        public string FileAttachmentValidDate { get; set; }

        public bool FileAttachmentStatus { get; set; }

        // public string FileAttachmentGroup { get; set; }
        public EType.DocumentTypeEnum DocumentType { get; set; }
        [ScriptIgnore]
        public virtual Document Document { get; set; }
        [ScriptIgnore]
        public virtual FileAttachment FileAttachment { get; set; }
      //  [NotMapped]
     //   public EType.State State { get; set; }
    }
}
