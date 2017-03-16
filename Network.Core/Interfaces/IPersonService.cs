using Network.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Core.Interfaces
{
    public interface IPersonService : IBaseService<Person, Guid>
    {
        T getMapperDTO<T>(Person entity);
        Person getFromMapperDTO<T>(T dto);
    }
}
