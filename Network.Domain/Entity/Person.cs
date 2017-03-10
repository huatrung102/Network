using Network.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Domain.Entity
{
    public class Person :BaseEntity
    {
        [Key]
        public Guid PersonId { get; set; }
        [MaxLength(50)]
        public string PersonName { get; set; }
        [MaxLength(50)]
        public string PersonPhone { get; set; }
        [MaxLength(50)]
        public string PersonPosition { get; set; }
     //   public Guid RefPartnerId { get; set; }
        // public virtual Partner Partner { get; set; }


    }
}
