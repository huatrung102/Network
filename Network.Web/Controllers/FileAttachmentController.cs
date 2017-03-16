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
    public class FileAttachmentController : BaseController<IFileAttachmentService, FileAttachment, Guid>
    {
        public FileAttachmentController() : base()
        {
            _IService = new FileAttachmentService(UnitOfWork);           

        }
        [HttpGet]
        // public FileResult DownloadDocument(string dto)
        public virtual ActionResult Download(string fileGuid, string fileName)
        {
            //FileAttachmentDTO file = MvcHelper.DeserializeObject<FileAttachmentDTO>(dto);
                try
                {                  
                    FileAttachment myFile = _IService.GetById(GuidHelper.CheckAndRefreshGuid(fileGuid));

                    if (myFile != null)
                    {
                        byte[] fileBytes = myFile.Content;
                    //var cd = new System.Net.Mime.ContentDisposition
                    //{
                    //    FileName = file.FileName,
                    //    Inline = true,
                    //};
                     //   Response.AppendHeader("Content-Disposition", cd.ToString());
                   
                        return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
                    }
                }
                catch(Exception ex)
                {
                throw ex;
                }
            //  

            return new EmptyResult();
        }
    }
}