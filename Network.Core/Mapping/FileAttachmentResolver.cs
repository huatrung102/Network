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
    public class FileAttachmentResolver : ValueResolver<ICollection<DocumentFileAttachment>, FileAttachment>
    {
        protected override FileAttachment ResolveCore(ICollection<DocumentFileAttachment> source)
        {
            // return source.Select(x => 
            //              Mapper.Map<DocumentFileAttachmentDTO, FileAttachment>(companies.FirstOrDefault(x => x.CompanyID == userCompany.CompanyID)))
            //     .ToList();
            return null;
        }
    }
}
