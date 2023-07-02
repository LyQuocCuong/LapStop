using Common.Models.Token;
using Common.Variables;
using Contracts.Utilities;
using Contracts.Utilities.Authentication;
using Domains.Identities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RestfulApiHandler.Helpers;
using RestfulApiHandler.ImpServices.Authentication;

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

        public static void RegisterDI_IdentityContext(this IServiceCollection services)
        {
            services.AddIdentity<IdentEmployee, IdentRole>(opt =>
            {
                opt.Password.RequireDigit = true;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredLength = 10;

                opt.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<LapStopContext>()
            .AddDefaultTokenProviders();
        }

        public static void RegisterDI_Repositories(this IServiceCollection services)
        {
            services.AddScoped<IDomainRepositories, DomainRepositories>();
        }

        public static void RegisterDI_Services(this IServiceCollection services)
        {
            services.AddScoped<IDomainServices, DomainServices>();
            services.AddScoped<UtilityServiceManager>();

            RegisterDI_NLog(services);
            RegisterDI_AutoMapper(services);
            RegisterDI_DataShaper(services);
            RegisterDI_Hateoas(services);
        }

        #region RegisterDI_Services

        private static void RegisterDI_NLog(this IServiceCollection services)
        {
            services.AddSingleton<ILogService, NLogService>();
        }

        private static void RegisterDI_AutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfiles));
            services.AddScoped<IMappingService, AutoMapperService>();
        }

        private static void RegisterDI_DataShaper(this IServiceCollection services)
        {
            services.AddScoped<IDataShaperService<EmployeeDto, ExpandoForXmlObject>, DataShaperService<EmployeeDto>>();
            services.AddScoped<IDataShaperService<BrandDto, ExpandoForXmlObject>, DataShaperService<BrandDto>>();
            services.AddScoped<IDataShaperService<CustomerDto, ExpandoForXmlObject>, DataShaperService<CustomerDto>>();
            services.AddScoped<IDataShaperService<ProductDto, ExpandoForXmlObject>, DataShaperService<ProductDto>>();
        }

        private static void RegisterDI_Hateoas(this IServiceCollection services)
        {
            services.AddScoped<IHateoasWithShaperService<BrandDto, ExpandoForXmlObject>, BrandDynamicHateoasWithShaperService>();
            services.AddScoped<IHateoasService<CustomerDto>, CustomerHateoasService>();
        }

        #endregion

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

            services.AddSwaggerGen(); // DEFAULT

            services.AddSwaggerGen(s =>
            {
                // Global Info
                s.SwaggerDoc(
                    name: "v1",
                    info: new OpenApiInfo
                    {
                        Title = "LQC_API_Ver1",
                        Version = "v1",
                        Description = "CompanyEmployees API by CodeMaze",
                        TermsOfService = new Uri("https://example.com/terms"),
                        Contact = new OpenApiContact 
                        { 
                            Name = "John Doe", 
                            Email = "John.Doe@gmail.com", 
                            Url = new Uri("https://twitter.com/johndoe"), 
                        },
                        License = new OpenApiLicense 
                        { 
                            Name = "CompanyEmployees API LICX", 
                            Url = new Uri("https://example.com/license"), 
                        }
                    });
                s.SwaggerDoc(
                    name: "v2",
                    info: new OpenApiInfo
                    {
                        Title = "LQC_API_Ver2",
                        Version = "v2"
                    });
                // end

                // Authentication
                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Description = "Place to add JWT with Bearer",
                    Name = "Authorization",
                    Scheme = "Bearer"
                });
                s.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {

                            Reference = new OpenApiReference()
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            },
                            Name = "Bearer"
                        },
                        new List<string>()
                    }
                });
                // end

                // Enable XML comments
                var xmlFile = $"{typeof(RestfulApiHandler.AssemblyReference).Assembly.GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                s.IncludeXmlComments(xmlPath);
                // end
            });
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
                    Limit = 50,
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

        public static void RegisterDI_JWT(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAuthentService, AuthentEmployeeService>();

            // Use BOTH 2 ways to get Configurations
            JwtConfiguration jwtConfiguration = new JwtConfiguration();
            configuration.Bind(jwtConfiguration.Section, jwtConfiguration);

            /// config for IOptions Patterns (IOptions, IOptionsSnapshot, IOptionMonitor)
            //services.Configure<JwtConfiguration>(configuration.GetSection("JwtSettings"));
            //services.Configure<JwtConfiguration>("JwtSnapShot", configuration.GetSection("JwtSettings"));
            //services.Configure<JwtConfiguration>("JwtMonitor", configuration.GetSection("JwtSettings"));

            CommonVariables.JwtTokenConfig
                .InitializeValues(
                    // Values are used to GENERATE the JWT Token
                    algorithmForSignature: SecurityAlgorithms.HmacSha256,
                    secretKey: Environment.GetEnvironmentVariable("SECRET"),
                    validIssuer: jwtConfiguration.ValidIssuer,
                    validAudience: jwtConfiguration.ValidAudience,
                    expirationMinutes: configuration.GetSection("JwtSettings")["expirationMinutes"],
                    // Values are used to VALIDATE the JWT Token
                    clockSkewMinutes: 0,
                    isShouldValidateIssuer: true,
                    isShouldValidateAudience: true,
                    isShouldValidateIssuerSigningKey: true,
                    isShouldValidateLifetime: true
                );

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = RestfulApiHelper.GetDefaultTokenValidationParams();
            });

        }

    }
}
