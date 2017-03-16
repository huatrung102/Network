using AutoMapper;
using Network.Common.Helper;
using Network.Core.Impl;
using Network.Core.Interfaces;
using Network.Domain.DTO;
using Network.Domain.Entity;
using Network.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Core.Mapping
{
    public class ModelMapping
    {
        public static void Register()
        {
            Mapper.Configuration.AllowNullCollections = true;
            //partner
            Mapper.CreateMap<Partner, PartnerDTO>().ReverseMap();
            //   Mapper.CreateMap<Person, PartnerDTO>()
            //  .ForMember(c => c.PartnerType, opt => opt.Ignore());
            //   Mapper.CreateMap<PartnerDTO, Person>();

            

            //location
            Mapper.CreateMap<Location, LocationDTO>()
            .ForMember(s => s.LocationLatitude,m => m.MapFrom(d=>d.LocationPoint.Latitude))
            .ForMember(s => s.LocationLongitude, m => m.MapFrom(d=> d.LocationPoint.Longitude));

            Mapper.CreateMap<Location, LocationReportDTO>()
           //http://stackoverflow.com/a/29788183/4177526
           //get all contracts history
           .ForMember(s => s.Contracts, m => m.MapFrom(d => d.Contracts.Select(Mapper.Map<Contract, ContractDTO>)))
           .ForMember(s => s.Staffs, m => m.MapFrom(d => Mapper.Map<List<StaffDTO>>(d.Staffs.Where(w => w.LocationId == d.LocationId))))
            .ForMember(s => s.Departments, m => m.MapFrom(d => Mapper.Map<List<DepartmentDTO>>(d.Staffs.Select(s => s.Department).ToList())))
            .ForMember(s => s.Documents, m => m.MapFrom(d => d.Documents.Select(Mapper.Map<Document, DocumentDTO>)))
           
            //.ForMember(s => s.DepartmentName, m => m.MapFrom(d => d.))
            //use for test purpose if Contract object not equal value ContractBalance and ContractDeposit
            .ForMember(s => s.Contract, m => m.MapFrom(d => d.Contracts.Where(l => (l.LocationId == d.LocationId)
                                && (l.ContractStatus.Equals(EType.StatusEnum.Available))).SingleOrDefault()))
            //get current value with active contract
            .ForMember(s => s.ContractBalance, m => m.MapFrom(d => d.Contracts.Where(l => (l.LocationId == d.LocationId) 
                                && (l.ContractStatus.Equals(EType.StatusEnum.Available))).SingleOrDefault().ContractBalance))
            .ForMember(s => s.ContractDeposit, m => m.MapFrom(d => d.Contracts.Where(l => (l.LocationId == d.LocationId) 
                                && (l.ContractStatus.Equals(EType.StatusEnum.Available))).SingleOrDefault().ContractDeposit))

            ;
            //  m.MapFrom(d => Mapper.Map<DepartmentDTO>(d.Staffs.Where(staff => staff.StaffIsHeadOffice).SingleOrDefault()
            //d.Staffs.Where(x => x.LocationId == d.LocationId).Single(l
            // l.)

            //        Mapper.CreateMap<UserBM, User>()
            //.ForMember(dest => dest.Location, opt =>
            //     opt.MapFrom(src => Mapper.Map<UserBM, Location>(src));

            Mapper.CreateMap<LocationDTO, Location>()
                .ForMember(s => s.LocationPoint, m => m.MapFrom(d => 
                GeoHelper.CreatePoint(d.LocationLatitude, d.LocationLongitude)));
            //department
            Mapper.CreateMap<Department, DepartmentDTO>()//.ReverseMap();
            .ForMember(s => s.DepartmentGroupName, m => m.MapFrom(d => d.DepartmentGroup));
            Mapper.CreateMap<DepartmentDTO, Department>();

            //    Mapper.CreateMap<DepartmentDTO, Department>();
            //List Staff
            Mapper.CreateMap<List<StaffDTO>, List<Staff>>();
            //staff
            Mapper.CreateMap<Staff, StaffDTO>()
            .ForMember(s => s.DepartmentName, m => m.MapFrom(d => d.Department.DepartmentName))
            .ForMember(s => s.PositionName, m => m.MapFrom(d=> d.Position.PositionName))
            .ForMember(s => s.LocationName, m => m.MapFrom(d => d.Location.LocationName))
            .ForMember(s => s.Department, m => m.MapFrom(d => Mapper.Map<DepartmentDTO>(d.Department)))
            ;

            Mapper.CreateMap<StaffDTO, Staff>();
             //   .ForMember(s => s.Position, m => m.re
                
          //      m.MapFrom(d => PositionSerivice.GetById(d.PositionId)));
            
            //position
            Mapper.CreateMap<PositionDTO, Position>().ReverseMap();
            //Document
            Mapper.CreateMap<DocumentDTO, Document>()
            .ForMember(p => p.LocationId, m => m.MapFrom(x => x.LocationId))
            .ForMember(p => p.DocumentFileAttachments, m => m.MapFrom(p =>
                            p.DocumentFileAttachments));

            Mapper.CreateMap<Document, DocumentDTO>()
            .ForMember(p => p.LocationName, m => m.MapFrom(p => p.Location.LocationName))
            .ForMember(p => p.DocumentFileAttachments, m => m.MapFrom(p =>
                            p.DocumentFileAttachments.ToList()));
            //Contract
            Mapper.CreateMap<ContractDTO, Contract>()
            .ForMember(p => p.LocationId, m => m.MapFrom(x => x.LocationId))
            .ForMember(p => p.ContractFirstPayDate, m => m.MapFrom(x => x.ContractFirstPayDate))
            .ForMember(p => p.ContractValidDate, m => m.MapFrom(x => x.ContractValidDate))
            .ForMember(p => p.ContractInvalidDate, m => m.MapFrom(x => x.ContractInvalidDate))
            .ForMember(p => p.ContractSignedDate, m => m.MapFrom(x => x.ContractSignedDate))

            .ForMember(p => p.ContractFileAttachments, m => m.MapFrom(p => p.ContractFileAttachments))
            
            ;

            Mapper.CreateMap<Contract, ContractDTO>()
            .ForMember(p => p.LocationName, m => m.MapFrom(p => p.Location.LocationName))
            .ForMember(p => p.ContractFileAttachments, m => m.MapFrom(p =>
                            p.ContractFileAttachments.ToList()))
            .ForMember(p => p.ContractFirstPayDate, m => m.MapFrom(x => x.ContractFirstPayDate != null ? x.ContractFirstPayDate.Value.ToString("dd/MM/yyyy"): null))
            .ForMember(p => p.ContractInvalidDate, m => m.MapFrom(x => x.ContractInvalidDate != null ? x.ContractInvalidDate.Value.ToString("dd/MM/yyyy") : null))
            .ForMember(p => p.ContractValidDate, m => m.MapFrom(x => x.ContractValidDate.ToString("dd/MM/yyyy")))
            .ForMember(p => p.ContractSignedDate, m => m.MapFrom(x => x.ContractSignedDate.ToString("dd/MM/yyyy")));


            //DocumentFileAttachment
            // Mapper.CreateMap<DocumentFileAttachmentDTO, DocumentFileAttachment>()
            //      .ForMember(p => p.FileAttachment,m => m.MapFrom(p => p.;


        }
    }
}
