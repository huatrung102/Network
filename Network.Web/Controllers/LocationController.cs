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
    public class LocationController : BaseController<ILocationService, Location, Guid>
    {
        public ActionResult Index()
        {
            return View(_IService.GetAllToView());
        }

        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(Location l)
        {
            try
            {
                l.LocationId = GuidHelper.CheckAndRefreshGuid(l.LocationId.ToString());               
                _IService.Add(l);
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
                Location l = _IService.GetById(GuidHelper.ConvertStrToGuid(id));
                return View(l);
            }
            catch (Exception)
            {
            }
            return View("Index");
        }

        // POST: Test/Edit/5
        [HttpPost]
        public ActionResult Edit(Location l)
        {
            try
            {                
                _IService.Update(l);
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
                Location l = _IService.GetById(GuidHelper.ConvertStrToGuid(id));
                l.IsDeleted = true;
                _IService.Update(l);

            }
            catch (Exception)
            {
            }
            return RedirectToAction("Index");

        }
    }
}