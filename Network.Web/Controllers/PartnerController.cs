using Network.Common.Extensions;
using Network.Common.Helper;
using Network.Core.Impl;
using Network.Core.Interfaces;
using Network.Domain.DTO;
using Network.Domain.Entity;
using Network.Domain.Enum;
using Network.Web.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Network.Web.Controllers
{
    public class PartnerController : BaseController<IPartnerService,Partner,Guid>
    {
       // public IEnumerable<Person> Persons;
       // private IPersonService _IPersonService;
        
        public PartnerController(): base() {
            _IService = new PartnerService(UnitOfWork);
           // _IPersonService = new PersonService(UnitOfWork);
        }
       
        // GET: Partner
        public ActionResult Index()
        {
           // _IService.GetAllToView()
            return View(new PartnerDTO());
            
        }

        public string getAllEntity()
        {
            var dto = _IService.GetAllToView()
                        .Select(p => _IService.getMapperDTO<PartnerDTO>(p))                        
                        .ToList();

            var json = MvcHelper.SerializeObject(dto, Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            return json;
        }
        // GET: Partner/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: Partner/Create
       
        private Partner getEntityFromDto(string dto)
        {
            PartnerDTO dtoObj = MvcHelper.DeserializeObject<PartnerDTO>(dto);
            Partner p = _IService.getFromMapperDTO(dtoObj);          
            return p;
        }
        // POST: Partner/Create
        [HttpPost]        
        public string Create(string dto)
        {
            try
            {               
                Partner p = getEntityFromDto(dto);  
                bool result =_IService.Add(p);
                return JsonOk();
           
            }
            catch (NWException ex)
            {
                return JsonError(ex);
            }
        }

       
       
        // POST: Partner/Edit/5
        [HttpPost]
        public string Edit(string id,string dto)
        {
            try
            {
                Partner p = getEntityFromDto(dto);
                bool result = _IService.Update(p);
                return JsonOk();
            }
            catch (NWException ex)
            {
                return JsonError(ex);
            }
        }

        // GET: Partner/Delete/5
        public ActionResult Delete(string id)
        {

            try
            {
                Partner p = _IService.GetById(GuidHelper.CheckAndRefreshGuid(id));
                p.IsDeleted = true;
                _IService.Update(p);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        
    }
}
