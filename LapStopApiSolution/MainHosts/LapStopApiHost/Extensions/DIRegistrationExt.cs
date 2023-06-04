using AutoMapperLib;
using AutoMapperLib.Profiles;
using Common.Models.DynamicObjects;
using Contracts.DataShaper;
using Contracts.IMapping;
using DTO.Input.FromBody.Creation;
using DTO.Output.Data;
using Entities.Context;
using Entities.InputDtoValidators.Creation;
using FluentValidation;
using LogicServices.DataShaper.UsingExpandoForXmlObject;
using Microsoft.EntityFrameworkCore;
using RestfulApiHandler.ActionFilters;

namespace LapStopApiHost.Extensions
{
    public static class DIRegistrationExt
    {
        public static void RegisterDI_LapStopContext(this IServiceCollection services, 
                                                        ConfigurationManager configManager)
        {
            services.AddDbContext<LapStopContext>(
                options => options.UseSqlServer(configManager.GetConnectionString("LapStopConnection"))
            );
        }

        public static void RegisterDI_AutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfiles));
            services.AddScoped<IMappingService, AutoMapperService>();
        }

        public static void RegisterDI_MarvinResponseCaching(this IServiceCollection services)
        {
            services.AddHttpCacheHeaders(
                (expirationOpt) =>
                {
                    // Just use to decorate the Reponse's Header (NOT check Expiration)
                    expirationOpt.MaxAge = 10;
                    expirationOpt.CacheLocation = Marvin.Cache.Headers.CacheLocation.Public;
                },
                (validationOpt) =>
                {
                    // [MustRevalidate = true] will STOPPING the [ResponseCaching - ReturnDataFromCache()].
                    // When [ResponseCaching] will get the data from Cache to return if MustRevalidate = false
                    // They are opposite each other.
                    validationOpt.MustRevalidate = true;
                }
            );
        }

        public static void RegisterDI_DotNetResponseCaching(this IServiceCollection services)
        {
            services.AddResponseCaching((options) =>
            {
                //options.SizeLimit = 1024;
                //options.MaximumBodySize = 1024;
                //options.UseCaseSensitivePaths = true;
            });
        }

        public static void RegisterDI_Swagger(this IServiceCollection services)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public static void RegisterDI_DataShaper(this IServiceCollection services)
        {
            services.AddScoped<IDataShaperService<EmployeeDto, ExpandoForXmlObject>, DataShaperService<EmployeeDto>>();
            services.AddScoped<IDataShaperService<BrandDto, ExpandoForXmlObject>, DataShaperService<BrandDto>>();
            services.AddScoped<IDataShaperService<CustomerDto, ExpandoForXmlObject>, DataShaperService<CustomerDto>>();
            services.AddScoped<IDataShaperService<ProductDto, ExpandoForXmlObject>, DataShaperService<ProductDto>>();
        }

        public static void RegisterDI_CustomValidationAttribute(this IServiceCollection services)
        {
            services.AddScoped<ValidationFilterAttribute>();
        }

        public static void RegisterDI_FluentValidation(this IServiceCollection services)
        {
            services.AddScoped<IValidator<BrandForCreationDto>, BrandForCreationValidator>();
        }

    }
}
