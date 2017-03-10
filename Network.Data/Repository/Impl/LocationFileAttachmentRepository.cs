using Network.Data.Repository.Interfaces;
using Network.Data.UoW;
using Network.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Data.Repository.Impl
{
    public class LocationFileAttachmentRepository: Repository<LocationFileAttachment, Guid>, ILocationFileAttachmentRepository
    {
        public LocationFileAttachmentRepository(UnitOfWork _context) : base(_context)
        {
        }
    }
}
