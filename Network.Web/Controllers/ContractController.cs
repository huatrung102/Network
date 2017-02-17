using Network.Common.Helper;
using Network.Core.Impl;
using Network.Core.Interfaces;
using Network.Domain.Entity;
using Network.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Network.Web.Controllers
{
    public class ContractController : BaseController<IContractService, Contract,Guid>
    {
        private IPartnerService _IPartnerService;
        private IDocumentService _IDocumentService;
        public ContractController(): base() {

            _IPartnerService = new PartnerService();
            _IDocumentService = new DocumentService();
        }
        public ActionResult Index()
        {
            return View(_IService.GetAllToView());
        }

        public ActionResult Create()
        {
            ViewBag.PartnerId = new SelectList(_IPartnerService.GetAllToView(), "PartnerId", "PartnerName");
            ViewBag.DocumentId = new SelectList(_IDocumentService.GetAllToView(), "DocumentId", "DocumentNumber");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Contract c)
        {
            try
            {
                c.ContractId = GuidHelper.CheckAndRefreshGuid(c.ContractId.ToString());
                c.ContractStatus = EType.StatusEnum.Available;
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
                Contract c = _IService.GetById(GuidHelper.ConvertStrToGuid(id));
                return View(c);
            }
            catch (Exception)
            {
            }
            return View("Index");
        }

        // POST: Test/Edit/5
        [HttpPost]
        public ActionResult Edit(Contract c)
        {
            try
            {
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
                Contract c = _IService.GetById(GuidHelper.ConvertStrToGuid(id));
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