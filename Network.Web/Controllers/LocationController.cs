using Network.Common.Extensions;
using Network.Common.Helper;
using Network.Core.Impl;
using Network.Core.Interfaces;
using Network.Domain.DTO;
using Network.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Network.Web.Controllers
{
    public class LocationController : BaseController<ILocationService, Location, Guid>
    {
        public ActionResult Index()
        {
            return View(new LocationDTO());
        }
        public LocationController(): base() {
            _IService = new LocationService(UnitOfWork);
            
        }
        public string getAllEntity()
        {
            var dto = _IService.GetAllToView().Select(p => _IService.getMapperDTO<LocationDTO>(p)).ToList();
            var json = MvcHelper.SerializeObject(dto, Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            return json;
        }

        
        public ActionResult Create()
        {

            return View();
        }

        private Location getLocationFromDto(string dto)
        {
            LocationDTO dtoObj = MvcHelper.DeserializeObject<LocationDTO>(dto);            
            Location p = _IService.getFromMapperDTO(dtoObj);           
            return p;
        }
        [HttpPost]
        public string Create(string dto)
        {
            try
            {
                Location p = getLocationFromDto(dto);
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
                Location p = getLocationFromDto(dto);
                bool result =  _IService.Update(p);
                return JsonOk();

            }
            catch (NWException ex)
            {
                return JsonError(ex);
            }
        }
        [HttpPost]
        public string LocationReport(string id)
        {

            return JsonOk();
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