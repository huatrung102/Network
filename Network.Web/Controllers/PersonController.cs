using Network.Common.Helper;
using Network.Core.Impl;
using Network.Core.Interfaces;
using Network.Data.UoW;
using Network.Domain.Entity;
using Network.Web.Test;
using System;
using System.Web.Mvc;

namespace Network.Web.Controllers
{
    public class PersonController : BaseController<IPersonService,Person,Guid>
    {      
        public PersonController()
        {
           
        }
        
        // GET: Home
        public ActionResult Index()
        {
            return View(_IService.GetAllToView());
        }

        public ActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Create(Person p)
        {
            try
            {
                p.PersonId = GuidHelper.CheckAndRefreshGuid(p.PersonId.ToString());
                //insert person
                _IService.Add(p);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public ActionResult Edit(string id)
        {
            try
            {

                Person p = _IService.GetById(GuidHelper.ConvertStrToGuid(id));
                return View(p);
            }
            catch (Exception)
            {
            }
            return View("Index");
        }

        // POST: Test/Edit/5
        [HttpPost]
        public ActionResult Edit(Person p)
        {
            try
            {
                //update person
                _IService.Update(p);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(string id)
        {
            try
            {
                //delete person but set isDeleted = true
                Person p = _IService.GetById(GuidHelper.ConvertStrToGuid(id));
                p.IsDeleted = true;
                _IService.Update(p);

            }
            catch (Exception)
            {
            }
            return RedirectToAction("Index");

        }
    }
}