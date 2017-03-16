using AutoMapper;
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
    public class DocumentService : BaseService<IDocumentRepository,Document, Guid>, IDocumentService
    {
        public DocumentService(UnitOfWork UnitOfWork) : base(UnitOfWork) {
            _IRepository = new DocumentRepository(_unitOfWork);
        }
        public DocumentService() : base() {
            _IRepository = new DocumentRepository(_unitOfWork);
        }
        //try
        //    {
        //        context.Set<TEntity>().AddOrUpdate(entityToUpdate);
        //context.UpdateGraph(entityToUpdate, map => map.OwnedCollection(p => p.));
        //        Commit();
        //        return true;
        //    }
        //    catch (NWException ex)
        //    {
        //        //throw ex;
        //    }
        //    return false;

        //not used
      //  public bool UpdateWithChilds(Document entityToUpdate, HashSet<Type> childTypes)        
      //     => _IRepository.UpdateWithChilds<Document>(entityToUpdate, childTypes);
        
    }
}
