using Network.Common.Helper;
using Network.Core.Interfaces;
using Network.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Network.Web.Controllers
{
    public class CostController : BaseController<ICostService,Cost,Guid>
    {
        // GET: Cost
        public ActionResult Index()
        {
            return View(_IService.GetAllToView());
        }

        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(Cost c)
        {
            try
            {
                c.CostId = GuidHelper.CheckAndRefreshGuid(c.CostId.ToString());
                //insert cost
                _IService.Add(c);
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

                Cost c = _IService.GetById(GuidHelper.CheckAndRefreshGuid(id));
                return View(c);
            }
            catch (Exception)
            {
            }
            return View("Index");
        }

        // POST: Test/Edit/5
        [HttpPost]
        public ActionResult Edit(Cost c)
        {
            try
            {
                //update person
                _IService.Update(c);
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
                Cost c = _IService.GetById(GuidHelper.CheckAndRefreshGuid(id));
                c.IsDeleted = true;
                _IService.Update(c);

            }
            catch (Exception)
            {
            }
            return RedirectToAction("Index");

        }
    }
}