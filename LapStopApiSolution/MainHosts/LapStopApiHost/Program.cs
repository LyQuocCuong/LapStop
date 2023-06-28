LogManager.Setup().LoadConfigurationFromFile(
    Path.Combine(Directory.GetCurrentDirectory(), 
    "../../Infrastructures/InfraServices/NLog/NLog.config")
);

var builder = WebApplication.CreateBuilder(args);

// right ABOVE the AddControllers() method
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    // disable 400 – Bad Request responses of [ApiController] attr
    options.SuppressModelStateInvalidFilter = true;  
});

builder.Services.AddControllers(config =>
    {
        // Tell a server to respect the Accept header
        config.RespectBrowserAcceptHeader = true;
        // Client tries to negotiate for the media type
        // the server doesn’t support
        config.ReturnHttpNotAcceptable = true; // 406 Not Acceptable
    })
    //.AddXmlDataContractSerializerFormatters() // support XML formatters
    //.AddMvcOptions(
    //        // support CSV (custom formatter)
    //        config => config.OutputFormatters.Add(new CsvOutputFormatter())
    //)
    .AddApplicationPart(typeof(RestfulApiHandler.AssemblyReference).Assembly);
    //.AddNewtonsoftJson();

builder.Services.SupportHateoasMediaTypeExt();  // after AddControllers()

builder.Services.RegisterDI_LapStopContext(builder.Configuration);

builder.Services.AddAuthentication();
builder.Services.RegisterDI_IdentityContext();

builder.Services.RegisterDI_Repositories();
builder.Services.RegisterDI_Services();

builder.Services.RegisterDI_CustomValidationAttribute();    // implement IActionFilter
builder.Services.RegisterDI_FluentValidation();             // FluentValidation.AspNetCore package
//builder.Services.RegisterDI_DotNetResponseCaching();      // [Expiration]
builder.Services.RegisterDI_MarvinResponseCaching();        // [Validation] Marvin.Cache.Header package
builder.Services.RegisterDI_ApiVersioning();
builder.Services.RegisterDI_RateLimit();
builder.Services.RegisterDI_JWT(builder.Configuration);
builder.Services.RegisterDI_Swagger();

var app = builder.Build();

// It is important to know that we have to extract the ILogService
// AFTER the var app = builder.Build() code line,
// because the Build method builds the WebApplication and REGISTER ALL the services added with IOC.
var logger = app.Services.GetRequiredService<ILogService>();
app.ConfigureExceptionHandler(logger);


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseIpRateLimiting();    // BEFORE Cors()

// UseCors must be called before UseResponseCaching
//app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

//app.UseResponseCaching();

app.UseHttpCacheHeaders();

app.MapControllers();

app.Run();
