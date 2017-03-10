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
       
        
        public enum PositionGroupEnum
        {
            BANLE = 0,
            TACNGHIEP = 1
        }
        public enum MoneyEnum
        {
            USD = 0,
            VND
        }

        public enum PartnerTypeEnum
        {
            [Display(Name ="Cá nhân")]
            CANHAN = 0,
            [Display(Name = "Công ty")]
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
           HopDong = 1,
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
            Monthly = 1,
            Quarterly = 3,
            SemiYearly = 6,
            Yearly = 12
        }
        
    }
}
