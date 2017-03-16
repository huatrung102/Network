using Network.Data.Repository.Interfaces;
using Network.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Data.Repository.Interfaces
{
    public interface IPersonRepository : IRepository<Person,Guid>
    {
    }
}
