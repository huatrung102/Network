using Network.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Domain.Entity
{
    public class Person : BaseEntity
    {
        [Key]
        public Guid PersonId { get; set; }
        [MaxLength(50)]
        public string PersonName { get; set; }
        [MaxLength(50)]
        public string PersonPhone { get; set; }
        [MaxLength(50)]
        public string PersonPosition { get; set; }
        [MaxLength(100)]
        public string PersonDescription { get; set; }

        public EType.PersonEnum PersonType { get; set; }
      //  public virtual Guid PartnerId { get; set; }
       // public virtual Partner Partner { get; set; }
        public virtual ICollection<Partner> Partners { get; set; }
        
    }
}
