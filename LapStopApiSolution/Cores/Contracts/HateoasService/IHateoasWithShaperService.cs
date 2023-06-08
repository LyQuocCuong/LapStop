using Contracts.DataShaperService;
using Microsoft.AspNetCore.Http;

namespace Contracts.HateoasService
{
    // Install: Microsoft.AspNetCore.Mvc.Abstractions to use HttpContext
    // We don't USE HttpContext right here, just DEFINE
    // => Choose "Abstraction" package
    public interface IHateoasWithShaperService<TAppliedModel, TReturnedDynamicObject>
    {
        IEnumerable<TReturnedDynamicObject> Execute(
            IDataShaperService<TAppliedModel, TReturnedDynamicObject> dataShaperService, 
            HttpContext httpContext, 
            IEnumerable<TAppliedModel> dataModelCollection, string? shapingPropsStr);

        TReturnedDynamicObject Execute(
            IDataShaperService<TAppliedModel, TReturnedDynamicObject> dataShaperService,
            HttpContext httpContext, 
            TAppliedModel dataModel, string? shapingPropsStr);
    }
}
