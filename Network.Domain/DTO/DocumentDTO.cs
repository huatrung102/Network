using Network.Domain.Entity;
using Network.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Network.Domain.DTO
{
    public class DocumentDTO
    {
        public DocumentDTO()
        {
            this.DocumentFileAttachments = new HashSet<DocumentFileAttachment>();
        }
        public Guid DocumentId { get; set; }
       
        public Guid LocationId { get; set; }
        public string LocationName { get; set; }
        //[ScriptIgnore]
      //  public virtual Location Location { get; set; }
     
        public string DocumentNumber { get; set; }

        //[ScriptIgnore]
        //    public virtual FileAttachment FileAttachment { get; set; }
        
        public virtual ICollection<DocumentFileAttachment> DocumentFileAttachments { get; set; }
      //  public string DocumentFileAttachmentsId { get; set; }

        public string DocumentDescription { get; set; }
        
        


    }
}
