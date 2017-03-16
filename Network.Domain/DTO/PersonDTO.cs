using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Domain.DTO
{
    public class PersonDTO
    {
        public Guid PersonId { get; set; }
        public string PersonName { get; set; }
        public string PersonPhone { get; set; }

    }
}
