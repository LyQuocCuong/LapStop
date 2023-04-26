using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.IServices
{
    public interface IServiceBase
    {
        TDestination MappingToNewObj<TDestination>(object source);
        object MappingToExistingObj(object fromSource, object toExistingDestination);
    }
}
