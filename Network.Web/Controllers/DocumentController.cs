using Network.Common.Extensions;
using Network.Common.Helper;
using Network.Core.Impl;
using Network.Core.Interfaces;
using Network.Domain.DTO;
using Network.Domain.Entity;
using Network.Web.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Network.Web.Controllers
{
    public class DocumentController : BaseController<IDocumentService, Document, Guid>
    {
        private ILocationService _ILocationService;
       // private IFileAttachmentService _IFileAttachmentService;
        private IDocumentFileAttachmentService _IDocumentFileAttachmentService;
       // static IDictionary<Guid, HttpPostedFileBase> ListFile = new Dictionary<Guid, HttpPostedFileBase>();
        private static readonly HashSet<Type> DocumentFileAttachmentChildTypes = new HashSet<Type>() { typeof(DocumentFileAttachment) };
        //ViewBag.ListFileUpload = new ;    
        public ActionResult Index()
        {
            return View(new DocumentDTO());
        }
        public DocumentController() : base()
        {
            _IService = new DocumentService(UnitOfWork);
            _ILocationService = new LocationService(UnitOfWork);
           // _IFileAttachmentService = new FileAttachmentService(UnitOfWork);
            _IDocumentFileAttachmentService = new DocumentFileAttachmentService(UnitOfWork);

        }
        public string getAllEntity()
        {
            var dto = _IService.GetAllToView().Select(p => _IService.getMapperDTO<DocumentDTO>(p)).ToList();
            dto.ForEach(s => s.DocumentFileAttachments.ToList().ForEach(doc => doc.FileAttachment.Content = default(byte[])));
            var json = MvcHelper.SerializeObject(dto, Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            return json;
            //  return Json(dto, JsonRequestBehavior.AllowGet);
        }

        private Document getEntityFromDto(string dto, HttpFileCollectionBase files)
        {
            DocumentDTO dtoObj = MvcHelper.DeserializeObject<DocumentDTO>(dto);
            Document p = _IService.getFromMapperDTO(dtoObj);
            if (files.Count == p.DocumentFileAttachments.Count)
            {
                for (int i = 0; i < p.DocumentFileAttachments.Count; i++)
                {
                    for (int j = 0; j < files.Count; j++)
                    {
                        Guid Key = GuidHelper.CheckAndRefreshGuid(files.GetKey(j));
                        if (p.DocumentFileAttachments.ElementAt(i).FileAttachmentId == Key)
                        {
                            p.DocumentFileAttachments.ElementAt(i).FileAttachment 
                                = FileUtil.CreateFileFromRequest(files[j]);
                        }
                    }
                }
               
                //p.Location = _ILocationService.GetById(p.LocationId);
                return p;
            }

            return null;


        }
        
        private Document getEntityFromDtoUpdate(string dto, HttpFileCollectionBase files)
        {

            DocumentDTO dtoObj = MvcHelper.DeserializeObject<DocumentDTO>(dto,Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            //document update from client
            Document p = _IService.getFromMapperDTO(dtoObj);
            
         //  ICollection<DocumentFileAttachment> tempFile = p.DocumentFileAttachments.ToList();
            //document from server
            Document doc = _IService.GetById(p.DocumentId);

            //remove file all
            // p.DocumentFileAttachments.Clear();

            p.DocumentFileAttachments.ToList().ForEach(s => s.IsDeleted = true);
            //  p.DocumentFileAttachments

            for (int i = 0; i < p.DocumentFileAttachments.Count; i++)
            {
                //thêm lại file vào danh sách tương ứng có trên client
                for (int k = 0; k < doc.DocumentFileAttachments.Count; k++)
                {
                    if (p.DocumentFileAttachments.ElementAt(i).FileAttachmentId == doc.DocumentFileAttachments.ElementAt(k).FileAttachmentId)
                    {
                        p.DocumentFileAttachments.ElementAt(i).IsDeleted = false;
                    }
                }
                
                //thêm file tương ứng với client đã chọn file (có thể update hoặc create mới)
                for (int j = 0; j < files.Count; j++)
                {
                    Guid Key = GuidHelper.CheckAndRefreshGuid(files.GetKey(j));
                    if (p.DocumentFileAttachments.ElementAt(i).FileAttachmentId == Key)
                    {
                        p.DocumentFileAttachments.ElementAt(i).FileAttachment = FileUtil.CreateFileFromRequest(files[j]);
                        p.DocumentFileAttachments.ElementAt(i).IsDeleted = false;
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
                Document p = getEntityFromDto(dtoStr, httpPostedFile);
                bool result = _IService.Add(p);

                return JsonOk();

            }
            catch (NWException ex)
            {
                return JsonError(ex);
            }
        }
       
        [HttpPost]
        public string Edit()
        {
            try
            {
                var httpPostedFile = Request.Files;
                var dtoStr = Request.Form["dto"];
                Document p = getEntityFromDtoUpdate(dtoStr, httpPostedFile);

                //   bool result = _IService.Update(p);
                bool result = _IService.UpdateWithChilds(p, DocumentFileAttachmentChildTypes);
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
                Document l = _IService.GetById(GuidHelper.ConvertStrToGuid(id));
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