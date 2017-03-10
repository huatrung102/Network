using Network.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Core.Interfaces
{
    public interface ILocationService : IBaseService<Location, Guid>
    {
        T getMapperDTO<T>(Location entity);
        Location getFromMapperDTO<T>(T dto);
    }
}
