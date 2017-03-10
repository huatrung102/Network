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
    //Bên cho thuê
    public class Partner : BaseEntity
    {
        public Partner()
        {
            this.Contracts = new HashSet<Contract>();
        }
        [Key]
        public Guid PartnerId { get; set; }
        //Tên người đại diện
        [MaxLength(50)]
        public string PartnerRepresentation { get; set; }
        //Tên bên cho thuê
        [MaxLength(50)]
        public string PartnerName { get; set; }
        [MaxLength(50)]
        public string PartnerPhone { get; set; }
        //loại cá nhân hay công ty
        public EType.PartnerTypeEnum PartnerType { get; set; }
        //địa chỉ người liên lạc
        [MaxLength(50)]
        public string PartnerPersonAddress { get; set; }
        //sđt người liên lạc
        [MaxLength(20)]
        public string PartnerPersonPhone { get; set; }
        //Tên người liên lạc
        [MaxLength(50)]
        public string PartnerPersonName { get; set; }
        //public Guid? PersonId { get; set; }
        //   [ForeignKey("PersonId")]
        // public virtual Person Person { get; set; }

        //có thể chưa có người liên hệ
        //     [ForeignKey("Person")]
        // public Guid? PersonId { get; set; }
        //   public virtual Person Person { get; set; }
        public ICollection<Contract> Contracts { get; set; }
    }
}
