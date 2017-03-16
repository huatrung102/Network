using Network.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Core.Interfaces
{
    public interface IDocumentService : IBaseService<Document, Guid>
    {
        bool UpdateWithChilds(Document entityToUpdate, HashSet<Type> childTypes);
    //    bool UpdateWithChildsTest(Document entityToUpdate, HashSet<Type> childTypes);
    }
}
