using Network.Common.DefineAttribute;
using Res;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Domain.Enum
{
    public class EType
    {
       
        
        public enum DepartmentGroupEnum
        {
            [LocalizedDescription("DepartmentGroupEnum_BANLE", typeof(GlobalResource))]
            BANLE = 0,
            [LocalizedDescription("DepartmentGroupEnum_TACNGHIEP", typeof(GlobalResource))]
            TACNGHIEP = 1
        }
        public enum MoneyEnum
        {
            USD = 0,
            VND
        }

        public enum PartnerTypeEnum
        {

            [LocalizedDescription("PartnerTypeEnum_CANHAN", typeof(GlobalResource))]
            CANHAN = 0,
            [LocalizedDescription("PartnerTypeEnum_CONGTY", typeof(GlobalResource))]
            CONGTY
            
        }

        public enum IntegrityPlanTypeEnum
        {
            TTT = 0,
            THT,
            TNT
        }
        public enum StatusEnum
        {
            Unavailable = 0,
            Available
        }

        public enum AreaTypeEnum
        {
            TPHCM = 0,
            MienBac ,
            MienTrung, 
            MienDongNamBo,
            DBSCL       
        }

        public enum LocationTypeEnum
        {
            PGD = 0,
            CHINHANH = 1
        }
        public enum FileGroupType
        {
            Contract = 0,
            IntegrityPlan,
            Location,
            
        }
        public enum StaffTypeEnum
        {
            [DisplayTextEnum("Manager")]
            LD = 1,
            [DisplayTextEnum("Employee")]
            CV =0
        }
        public enum DocumentTypeEnum
        {
            QD_HDTV_THANHLAP = 0,
            CV_NHNN_CHAPTHUAN,
            DKKD,
            QD_KHAITRUONG,
            
        }
        public enum ContractTypeEnum
        {
            [LocalizedDescription("ContractTypeEnum_HopDong", typeof(GlobalResource))]
            HopDong = 1,
            [LocalizedDescription("ContractTypeEnum_Phuluc", typeof(GlobalResource))]
            Phuluc ,
            
        }

        public enum DocumentPartnerHpTypeEnum
        {
            [DisplayTextEnum("Current")]
            Current = 1,
            [DisplayTextEnum("Old")]
            Old = 0
        }

        public enum FileAttachmentGroup
        {

        }
        public enum State
        {
            Added,
            Unchanged,
            Modified,
            Deleted
        }
        public enum SchedulePaymentEnum
        {
            [LocalizedDescription("SchedulePaymentEnum_MONTHLY", typeof(GlobalResource))]
            Monthly = 1,
            [LocalizedDescription("SchedulePaymentEnum_QUARTERLY", typeof(GlobalResource))]
            Quarterly = 3,
            [LocalizedDescription("SchedulePaymentEnum_SEMIYEARLY", typeof(GlobalResource))]
            SemiYearly = 6,
            [LocalizedDescription("SchedulePaymentEnum_YEARLY", typeof(GlobalResource))]
            Yearly = 12
        }
        
    }
}
