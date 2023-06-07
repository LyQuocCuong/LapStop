using Microsoft.AspNetCore.Http;

namespace Common.Models.Hateoas
{
    public class HateoasParameters<TModelParameter>
    {
        public HttpContext HttpContext { get; set; }
        public TModelParameter RequestParam { get; set; }

        public HateoasParameters(HttpContext httpContext, TModelParameter requestParam)
        {
            this.HttpContext = httpContext;
            this.RequestParam = requestParam;
        }
    }
}
