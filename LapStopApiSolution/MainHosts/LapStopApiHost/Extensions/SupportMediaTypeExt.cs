using Microsoft.AspNetCore.Mvc.Formatters;

namespace LapStopApiHost.Extensions
{
    public static class SupportMediaTypeExt
    {
        public static void SupportHateoasMediaTypeExt(this IServiceCollection services)
        {
            services.Configure<MvcOptions>(config =>
            {
                var systemTextJsonOutputFormatter = config.OutputFormatters.
                                OfType<SystemTextJsonOutputFormatter>()?.FirstOrDefault();
                if (systemTextJsonOutputFormatter != null)
                {
                    systemTextJsonOutputFormatter.SupportedMediaTypes.
                                            Add("application/api.lapstop.hateoas+json");
                    systemTextJsonOutputFormatter.SupportedMediaTypes.
                                            Add("application/api.lapstop.apiroot+json");
                }

                var xmlOutputFormatter = config.OutputFormatters.
                                OfType<XmlDataContractSerializerOutputFormatter>()?.FirstOrDefault();
                if (xmlOutputFormatter != null)
                {
                    xmlOutputFormatter.SupportedMediaTypes.
                                    Add("application/api.lapstop.hateoas+xml");
                    xmlOutputFormatter.SupportedMediaTypes.
                                    Add("application/api.lapstop.apiroot+xml");
                }
            });
        }
    }
}
