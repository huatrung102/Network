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
    
    public class BaseController<IBaseService, TEntity, TKey> : Controller 
        where TEntity : BaseEntity
        
    {
        protected UnitOfWork UnitOfWork;
        protected IBaseService<TEntity, TKey> _IService;
        protected BaseService<TEntity,TKey> _IBaseService;
        public string AnotherLink { get; set; }
        public BaseController()
        {
            _IService = new BaseService<TEntity, TKey>() ;
        }
        public BaseController(string anotherLink)
        {
            AnotherLink = anotherLink;
        }
        


    }
}