using DTO.Input.FromQuery.Parameters;
using Microsoft.AspNetCore.Http;

namespace Common.Models.HATEOAS
{
    public class HateoasParameters<TModelParameter>
    {
        public HttpContext HttpContext { get; set; }
        public TModelParameter RequestParams { get; set; }

        public HateoasParameters(HttpContext httpContext, TModelParameter modelParameter)
        {
            this.HttpContext = httpContext;
            this.RequestParams = modelParameter;
        }

    }
}
