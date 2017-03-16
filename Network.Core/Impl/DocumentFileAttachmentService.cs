using Network.Core.Interfaces;
using Network.Data.Repository.Impl;
using Network.Data.Repository.Interfaces;
using Network.Data.UoW;
using Network.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Core.Impl
{
    public class DocumentFileAttachmentService : 
        BaseService<IDocumentFileAttachmentRepository,DocumentFileAttachment, Tuple<Guid, Guid>>
        ,IDocumentFileAttachmentService
    {
        public DocumentFileAttachmentService(UnitOfWork UnitOfWork) : base(UnitOfWork) {
            _IRepository = new DocumentFileAttachmentRepository(_unitOfWork);
        }
        public DocumentFileAttachmentService() : base() {
            _IRepository = new DocumentFileAttachmentRepository(_unitOfWork);
        }



    }
}
