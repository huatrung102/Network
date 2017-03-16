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
    public class DocumentPartnerHP : BaseEntity
    {
        [Key, ForeignKey("DocumentHP"), Column(Order = 1)]
        public Guid DocumentHPId { get; set; }
        [Key, ForeignKey("PartnerHP"), Column(Order = 0)]
        public Guid PartnerHPId { get; set; }

        public virtual PartnerHP PartnerHP { get; set; }
        public virtual DocumentHP DocumentHP { get; set; }
        //chủ đầu tư hiện tại hay chủ đầu tư trước đó
        public EType.DocumentPartnerHpTypeEnum DocumentPartnerHpType { get; set; }
    }
}
