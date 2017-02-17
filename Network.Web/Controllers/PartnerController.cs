using Network.Common.Helper;
using Network.Core.Impl;
using Network.Core.Interfaces;
using Network.Domain.Entity;
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
        private IPersonService _IPersonService;
        public PartnerController(): base() {
            _IPersonService = new PersonService(new Data.UoW.UnitOfWork());
            
        }
        // GET: Partner
        public ActionResult Index()
        {
            return View(_IService.GetAllToView());
            
        }

        // GET: Partner/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Partner/Create
        public ActionResult Create()
        {
            ViewBag.PersonId = new SelectList(_IPersonService.GetAllToView(),"PersonId","PersonName") ;
            return View();
        }

        // POST: Partner/Create
        [HttpPost]
        public ActionResult Create(Partner p)
        {
            try
            {                
                p.PartnerId = GuidHelper.CheckAndRefreshGuid(p.PartnerId.ToString());                
                _IService.Add(p);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Partner/Edit/5
        public ActionResult Edit(string id)
        {
            Partner p = _IService.GetById(GuidHelper.ConvertStrToGuid(id));
            ViewBag.PersonId = new SelectList(_IPersonService.GetAllToView(), "PersonId", "PersonName");
            return View(p);
        }

        // POST: Partner/Edit/5
        [HttpPost]
        public ActionResult Edit(Partner p)
        {
            try
            {

                _IService.Update(p);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Partner/Delete/5
        public ActionResult Delete(string id)
        {

            try
            {
                Partner p = _IService.GetById(GuidHelper.ConvertStrToGuid(id));
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
