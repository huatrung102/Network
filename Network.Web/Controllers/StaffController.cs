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
    public class StaffController : BaseController<IStaffService, Staff, Guid>
    {
        IPositionService _IPositionService;
        public ActionResult Index()
        {
            return View(new StaffDTO());
        }
        public StaffController(): base() {
            _IService = new StaffService(UnitOfWork);
            _IPositionService = new PositionService(UnitOfWork);
        }
        public JsonResult getAllEntity()
        {
            var dto = _IService.GetAllToView().Select(p => _IService.getMapperDTO<StaffDTO>(p));
            dto.Where(p => p.StaffIsHeadOffice).ToList().ForEach(p => p.StaffExistHeadOffice = true);

            return Json(dto, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Create()
        {

            return View();
        }

        private Staff getEntityFromDto(string dto)
        {
            StaffDTO dtoObj = MvcHelper.DeserializeObject<StaffDTO>(dto);
            Staff p = _IService.getFromMapperDTO(dtoObj);
            p.Position = _IPositionService.GetById(p.PositionId);
            return p;
        }
        [HttpPost]
        public string Create(string dto)
        {
            try
            {
                Staff p = getEntityFromDto(dto);
                
               if (p.Position != null && p.Position.PositionIsLeader)
                {
                    //định danh chi tiết cán bộ --> 1
                    p.StaffCount = 1;

                }else
                {
                    //neu1 là nhân viên thì không thể làm ng đứng đầu
                    p.StaffIsHeadOffice = false;
                }
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
                Staff p = getEntityFromDto(dto);
               
                if (p.Position != null && p.Position.PositionIsLeader)
                {
                    //định danh chi tiết cán bộ --> 1
                    p.StaffCount = 1;

                }
                else
                {
                    //neu1 là nhân viên thì không thể làm ng đứng đầu
                    p.StaffIsHeadOffice = false;
                }
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
                Staff l = _IService.GetById(GuidHelper.ConvertStrToGuid(id));
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