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

        public static void RegisterDI_Hateoas(this IServiceCollection services)
        {
            services.AddScoped<IHateoasWithShaperService<BrandDto, ExpandoForXmlObject>, BrandDynamicHateoasWithShaperService>();
            services.AddScoped<IHateoasService<CustomerDto>, CustomerHateoasService>();
        }

        public static void RegisterDI_CustomValidationAttribute(this IServiceCollection services)
        {
            services.AddScoped<ValidationFilterAttribute>();
            services.AddScoped<ValidateRequestNotMissingMediaTypeAttr>();
        }

        public static void RegisterDI_FluentValidation(this IServiceCollection services)
        {
            services.AddScoped<IValidator<BrandForCreationDto>, BrandForCreationValidator>();
        }

        public static void RegisterDI_ApiVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(opt =>
            {
                // add Api's version to Response Header
                opt.ReportApiVersions = true;

                // init a default version
                opt.DefaultApiVersion = new ApiVersion(1,0);

                // set Api's version = (default) - if Clients don't send
                opt.AssumeDefaultVersionWhenUnspecified = true;

                //// Conventions (Do NOT need [ApiVersion] in Controllers)
                //opt.Conventions.Controller<BrandController>()
                //               .HasDeprecatedApiVersion(new ApiVersion(1, 0));

                //opt.Conventions.Controller<BrandV2Controller>()
                //               .HasApiVersion(new ApiVersion(2, 0));

            });
        }

        public static void RegisterDI_RateLimit(this IServiceCollection services)
        {
            services.AddMemoryCache();  // use MemoryCache to store Counters, Rules

            var rateLimitRules = new List<RateLimitRule>
            {
                new RateLimitRule
                {
                    Endpoint = "*",
                    Limit = 3,
                    Period = "5m"
                }
            };

            services.Configure<IpRateLimitOptions>(opt => 
            { 
                opt.GeneralRules = rateLimitRules; 
            });
            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();

            services.AddHttpContextAccessor();  // register HttpContextAccessor
        }

    }
}
