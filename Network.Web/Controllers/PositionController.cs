using Network.Common.Extensions;
using Network.Common.Helper;
using Network.Core.Impl;
using Network.Core.Interfaces;
using Network.Domain.DTO;
using Network.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Network.Web.Controllers
{
    public class PositionController : BaseController<IPositionService, Position, Guid>
    {

        public JsonResult getAllEntity()
        {
            var dto = _IService.GetAllToView().Select(p => _IService.getMapperDTO<PositionDTO>(p)).ToList();

            return Json(dto, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            return View(new PositionDTO());
        }
        public PositionController(): base() {
            _IService = new PositionService(UnitOfWork);

        }
        
        public ActionResult Create()
        {

            return View();
        }

        private Position getEntityFromDto(string dto)
        {
            PositionDTO dtoObj = MvcHelper.DeserializeObject<PositionDTO>(dto);
            Position p = _IService.getFromMapperDTO(dtoObj);
            return p;
        }
        [HttpPost]
        public string Create(string dto)
        {
            try
            {
                Position p = getEntityFromDto(dto);
                bool result = _IService.Add(p);
                return JsonOk();

            }
            catch (NWException ex)
            {
                return JsonError(ex);
            }
        }

        // POST: Test/Edit/5
        [HttpPost]
        public string Edit(string dto)
        {
            try
            {
                Position p = getEntityFromDto(dto);
                bool result = _IService.Update(p);
                return JsonOk();

            }
            catch (NWException ex)
            {
                return JsonError(ex);
            }
        }

        public ActionResult Delete(string id)
        {
            try
            {
                Position l = _IService.GetById(GuidHelper.CheckAndRefreshGuid(id));
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