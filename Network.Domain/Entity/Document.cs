using Network.Common.DefineAttribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Domain.Entity
{
    public class Document : BaseEntity
    {
       
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
        public virtual ICollection<Contract> Contracts { get; set; }

       // public virtual ICollection<FileAttachment> ContractFiles { get; set; }
    }
}
