using Network.Common.Extensions;
using Network.Common.Helper;
using Network.Core.Impl;
using Network.Core.Interfaces;
using Network.Domain.DTO;
using Network.Domain.Entity;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Network.Web.Controllers
{
    public class DepartmentController : BaseController<IDepartmentService, Department, Guid>
    {
        public ActionResult Index()
        {
            return View(new DepartmentDTO());
        }
        public DepartmentController(): base() {
            _IService = new DepartmentService(UnitOfWork);

        }
        public JsonResult getAllEntity()
        {
            var dto = _IService.GetAllToView().Select(p => _IService.getMapperDTO<DepartmentDTO>(p)).ToList();

            return Json(dto, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Create()
        {

            return View();
        }

        private Department getEntityFromDto(string dto)
        {
            DepartmentDTO dtoObj = MvcHelper.DeserializeObject<DepartmentDTO>(dto);
            Department p = _IService.getFromMapperDTO(dtoObj);
            return p;
        }
        [HttpPost]
        public string Create(string dto)
        {
            try
            {
                Department p = getEntityFromDto(dto);
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
                Department p = getEntityFromDto(dto);
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
                Department l = _IService.GetById(GuidHelper.ConvertStrToGuid(id));
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