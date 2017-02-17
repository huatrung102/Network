using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Domain.Entity
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            this.IsDeleted = false;
        }
       // [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public DateTime CreatedOn { get; set; }
      //  [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public DateTime ModifiedOn { get; set; }
       [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public bool IsDeleted { get; set; }
    }
}
