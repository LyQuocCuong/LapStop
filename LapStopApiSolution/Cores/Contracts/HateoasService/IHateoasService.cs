using Microsoft.AspNetCore.Http;

namespace Contracts.HateoasService
{
    // Install: Microsoft.AspNetCore.Mvc.Abstractions to use HttpContext
    // We don't USE HttpContext right here, just DEFINE
    // => Choose "Abstraction" package
    public interface IHateoasService<TAppliedModel, TReturnedDynamicObject>
    {
        IEnumerable<TReturnedDynamicObject> ExecuteHateoas(HttpContext httpContext, IEnumerable<TAppliedModel> dataModelCollection, string requiredPropsStr);
        TReturnedDynamicObject ExecuteHateoas(HttpContext httpContext, TAppliedModel dataModel, string requiredPropsStr);
    }
}
