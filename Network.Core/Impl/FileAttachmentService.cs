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
    public class FileAttachmentService : BaseService<IFileAttachmentRepository ,FileAttachment, Guid>, IFileAttachmentService
    {
        public FileAttachmentService(UnitOfWork UnitOfWork) : base(UnitOfWork) {
            _IRepository = new FileAttachmentRepository(_unitOfWork);
        }
        public FileAttachmentService() : base() {
            _IRepository = new FileAttachmentRepository(_unitOfWork);
        }


    }
}
