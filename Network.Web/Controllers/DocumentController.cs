using Network.Common.Helper;
using Network.Core.Impl;
using Network.Core.Interfaces;
using Network.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Network.Web.Controllers
{
    public class DocumentController : BaseController<IDocumentService, Document,Guid>
    {
        private ILocationService _ILocationService;
        public DocumentController()
        {
            _ILocationService = new LocationService();
        }
        public ActionResult Index()
        {
            return View(_IService.GetAllToView());
        }

        public ActionResult Create()
        {
            ViewBag.LocationId = new SelectList(_ILocationService.GetAllToView(), "LocationId", "LocationName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Document d)
        {
            try
            {
                d.DocumentId = GuidHelper.CheckAndRefreshGuid(d.DocumentId.ToString());
                _IService.Add(d);
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
                Document d = _IService.GetById(GuidHelper.ConvertStrToGuid(id));
                return View(d);
            }
            catch (Exception)
            {
            }
            return View("Index");
        }

        // POST: Test/Edit/5
        [HttpPost]
        public ActionResult Edit(Document d)
        {
            try
            {
                _IService.Update(d);
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
                Document d = _IService.GetById(GuidHelper.ConvertStrToGuid(id));
                d.IsDeleted = true;
                _IService.Update(d);

            }
            catch (Exception)
            {
            }
            return RedirectToAction("Index");

        }
    }
}