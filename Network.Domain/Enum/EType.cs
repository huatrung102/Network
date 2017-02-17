using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Domain.Enum
{
    public class EType
    {
        public enum MoneyEnum
        {
            USD = 0,
            VND
        }

        public enum PersonEnum
        {
            CBNV = 0,
            CBAMC,
            Partner
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

        public enum AreaType
        {
            TPHCM = 0,
            MienBac ,
            MienTrung, 
            MienDongNamBo,
            DBSCL       
        }
        public enum FileGroupType
        {
            Contract = 0,
            IntegrityPlan,
            Location,
            
        }

    }
}
