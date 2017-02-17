using Network.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Domain.DTO
{
    public class ContractDTO
    {
        public Contract Contract { get; set; }
        public List<FileAttachment> FileAttachments { get; set; }

    }
}
