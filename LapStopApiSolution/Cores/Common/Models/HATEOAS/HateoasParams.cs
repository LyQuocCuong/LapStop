using Microsoft.AspNetCore.Http;

namespace Common.Models.Hateoas
{
    public class HateoasParams<TModelRequestParam>
    {
        public HttpContext HttpContext { get; set; }
        public TModelRequestParam RequestParams { get; set; }

        public HateoasParams(HttpContext httpContext, TModelRequestParam requestParam)
        {
            this.HttpContext = httpContext;
            this.RequestParams = requestParam;
        }
    }
}
