using Microsoft.AspNetCore.Http;

namespace Contracts.Hateoas
{
    // Install: Microsoft.AspNetCore.Mvc.Abstractions to use HttpContext
    // We don't USE HttpContext right here, just DEFINE
    // => Choose "Abstraction" package
    public interface IHateoasService<TAppliedModel>
    {
        IEnumerable<TAppliedModel> Execute(HttpContext httpContext, IEnumerable<TAppliedModel> dataModelCollection);

        TAppliedModel Execute(HttpContext httpContext, TAppliedModel dataModel);
    }
}
