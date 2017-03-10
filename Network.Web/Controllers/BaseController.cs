using Network.Common.Extensions;
using Network.Common.Helper;
using Network.Core.Impl;
using Network.Core.Interfaces;
using Network.Data.UoW;
using Network.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Network.Web.Controllers
{
    
    public class BaseController<IService, TEntity, TKey> : Controller 
        where TEntity : BaseEntity
        where IService: IBaseService<TEntity, TKey>
       
    {
        protected UnitOfWork UnitOfWork;
        protected IService _IService;
        //protected IBaseService<TEntity,TKey> _IBaseService;
        public string AnotherLink { get; set; }
        public BaseController()
        {
            UnitOfWork = UnitOfWork == null ? new UnitOfWork() : UnitOfWork;
          //  _IService = new BaseService<TEntity, TKey>() ;
        }
        public BaseController(IBaseService<TEntity, TKey> _IService)
        {
           // this._IService = _IService;
        }
        public BaseController(string anotherLink)
        {
            AnotherLink = anotherLink;
        }
        
        protected string JsonOk()
        {
            return MvcHelper.getResponse(ResponseConstants.OK);
        }
        protected string JsonOk<T>(T data)
        {
            return MvcHelper.getResponse(ResponseConstants.OK,data);
        }
        protected string JsonError(NWException ex)
        {
            return MvcHelper.getResponse(ex.ErrorCode, new JsonError(ex.Message,ex.ErrorCode));            
           
        }
        protected string JsonError<T>(NWException ex,T data)
        {
            return MvcHelper.getResponse(ex.ErrorCode, data, new JsonError(ex.Message, ex.ErrorCode));
        }


    }
}