using Network.Common.Extensions;
using Network.Common.Helper;
using Network.Core.Impl;
using Network.Core.Interfaces;
using Network.Domain.DTO;
using Network.Domain.Entity;
using Network.Domain.Enum;
using Network.Web.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Network.Web.Controllers
{
    public class ContractController : BaseController<IContractService, Contract, Guid>
    {
        private IPartnerService _IPartnerService;
        private ILocationService _ILocationService;
        private static readonly HashSet<Type> ContractFileAttachmentChildTypes = new HashSet<Type>() { typeof(ContractFileAttachment) };
        public ContractController() : base()
        {
            _IService = new ContractService(UnitOfWork);
            _IPartnerService = new PartnerService(UnitOfWork);
            _ILocationService = new LocationService(UnitOfWork);
        }
        public ActionResult Index()
        {
            return View(new ContractDTO());
        }
        public string getAllEntity()
        {
            var dto = _IService.GetAllToView()
                        .Select(p => _IService.getMapperDTO<ContractDTO>(p)).ToList();
            dto.ForEach(s => s.ContractFileAttachments.ToList().ForEach(doc => doc.FileAttachment.Content = default(byte[])));
            var json = MvcHelper.SerializeObject(dto, Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            return json;
        }



        private Contract getEntityFromDto(string dto, HttpFileCollectionBase files)
        {
            ContractDTO dtoObj = MvcHelper.DeserializeObject<ContractDTO>(dto);
            Contract p = _IService.getFromMapperDTO(dtoObj);
            if (files.Count == p.ContractFileAttachments.Count)
            {
                for (int i = 0; i < p.ContractFileAttachments.Count; i++)
                {
                    for (int j = 0; j < files.Count; j++)
                    {
                        Guid Key = GuidHelper.CheckAndRefreshGuid(files.GetKey(j));
                        if (p.ContractFileAttachments.ElementAt(i).FileAttachmentId == Key)
                        {
                            p.ContractFileAttachments.ElementAt(i).FileAttachment
                                = FileUtil.CreateFileFromRequest(files[j]);
                        }
                    }
                }
                return p;
            }
            return null;
        }
        private Contract getEntityFromDtoUpdate(string dto, HttpFileCollectionBase files)
        {

            ContractDTO dtoObj = MvcHelper.DeserializeObject<ContractDTO>(dto, Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            //document update from client
            Contract p = _IService.getFromMapperDTO(dtoObj);

            //  ICollection<DocumentFileAttachment> tempFile = p.DocumentFileAttachments.ToList();
            //document from server
            Contract doc = _IService.GetById(p.ContractId);

            //remove file all
            // p.DocumentFileAttachments.Clear();

            p.ContractFileAttachments.ToList().ForEach(s => s.IsDeleted = true);
            //  p.DocumentFileAttachments

            for (int i = 0; i < p.ContractFileAttachments.Count; i++)
            {
                //thêm lại file vào danh sách tương ứng có trên client
                for (int k = 0; k < doc.ContractFileAttachments.Count; k++)
                {
                    if (p.ContractFileAttachments.ElementAt(i).FileAttachmentId == doc.ContractFileAttachments.ElementAt(k).FileAttachmentId)
                    {
                        p.ContractFileAttachments.ElementAt(i).IsDeleted = false;
                    }
                }

                //thêm file tương ứng với client đã chọn file (có thể update hoặc create mới)
                for (int j = 0; j < files.Count; j++)
                {
                    Guid Key = GuidHelper.CheckAndRefreshGuid(files.GetKey(j));
                    if (p.ContractFileAttachments.ElementAt(i).FileAttachmentId == Key)
                    {
                        p.ContractFileAttachments.ElementAt(i).FileAttachment = FileUtil.CreateFileFromRequest(files[j]);
                        p.ContractFileAttachments.ElementAt(i).IsDeleted = false;
                    }
                }

            }

            //   p.LocationId = _ILocationService.GetById(p.LocationId);
            //            doc = p;
            return p;


        }
        [HttpPost]
        public string Create()
        {
            try
            {
                var httpPostedFile = Request.Files;
                var dtoStr = Request.Form["dto"];
                Contract p = getEntityFromDto(dtoStr, httpPostedFile);
                
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
                var httpPostedFile = Request.Files;
                var dtoStr = Request.Form["dto"];
                Contract p = getEntityFromDtoUpdate(dtoStr, httpPostedFile);

                //   bool result = _IService.Update(p);
                bool result = _IService.UpdateWithChilds(p, ContractFileAttachmentChildTypes);
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
                Contract c = _IService.GetById(GuidHelper.CheckAndRefreshGuid(id));
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