using Network.Core.Impl;
using Network.Core.Interfaces;
using Network.Data.Repository.Impl;
using Network.Data.Repository.Interfaces;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Network.Web.App_Start
{
    public class WebNinjectModule : NinjectModule
    {
        public override void Load()
        {
            #region Services
            //Bind<IPersonService>().To<PersonService>();
            Bind<IPartnerService>().To<PartnerService>();
            Bind<ILocationService>().To<LocationService>();
          //  Bind<IIntegrityPlanService>().To<IntegrityPlanService>();
         //   Bind<IFileAttachmentService>().To<FileAttachmentService>();
          //  Bind<IECMService>().To<ECMService>();
         //   Bind<IDocumentService>().To<DocumentService>();
         //   Bind<ICostService>().To<CostService>();
            Bind<IContractService>().To<ContractService>();
            #endregion

            #region Repositories
            Bind<IPersonRepository>().To<PersonRepository>();
            Bind<IPartnerRepository>().To<PartnerRepository>();
            Bind<ILocationRepository>().To<LocationRepository>();
            Bind<IIntegrityPlanRepository>().To<IntegrityPlanRepository>();
            Bind<IFileAttachmentRepository>().To<FileAttachmentRepository>();
            Bind<IECMRepository>().To<ECMRepository>();
         //   Bind<IDocumentRepository>().To<DocumentRepository>();
            Bind<ICostRepository>().To<CostRepository>();
            Bind<IContractRepository>().To<ContractRepository>();


            #endregion
        }
    }
}