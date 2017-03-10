using AutoMapper;
using Network.Common.Helper;
using Network.Core.Impl;
using Network.Core.Interfaces;
using Network.Domain.DTO;
using Network.Domain.Entity;
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
            
            Mapper.CreateMap<LocationDTO, Location>()
                .ForMember(s => s.LocationPoint, m => m.MapFrom(d => 
                GeoHelper.CreatePoint(d.LocationLatitude, d.LocationLongitude)));
            //department
            Mapper.CreateMap<Department, DepartmentDTO>()
            .ForMember(s => s.LocationName, m => m.MapFrom(d => d.Location.LocationName));
            Mapper.CreateMap<DepartmentDTO, Department>();
            //staff
            Mapper.CreateMap<Staff, StaffDTO>()
            .ForMember(s => s.DepartmentName, m => m.MapFrom(d => d.Department.DepartmentName))
            .ForMember(s => s.PositionName, m => m.MapFrom(d=> d.Position.PositionName));
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
            .ForMember(p => p.ContractInvalidDate, m => m.MapFrom(x => x.ContractInvalidDate != null ? x.ContractFirstPayDate.Value.ToString("dd/MM/yyyy") : null))
            .ForMember(p => p.ContractValidDate, m => m.MapFrom(x => x.ContractValidDate.ToString("dd/MM/yyyy")))
            .ForMember(p => p.ContractSignedDate, m => m.MapFrom(x => x.ContractSignedDate.ToString("dd/MM/yyyy")));


            //DocumentFileAttachment
            // Mapper.CreateMap<DocumentFileAttachmentDTO, DocumentFileAttachment>()
            //      .ForMember(p => p.FileAttachment,m => m.MapFrom(p => p.;


        }
    }
}
