using AutoMapper;
using Network.Domain.DTO;
using Network.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Core.Mapping
{
    public class FileAttachmentResolver : ValueResolver<ICollection<Department>, DepartmentDTO>
    {
        protected override DepartmentDTO ResolveCore(ICollection<Department> source)
        {
            
            return null;
        }
    }
}
