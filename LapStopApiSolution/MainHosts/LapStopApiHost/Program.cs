using Contracts.IDataShaper;
using Contracts.ILog;
using Contracts.IRepositories;
using Contracts.IServices;
using DTO.Input.FromBody.Creation;
using DTO.Output.Data;
using Entities.Context;
using Entities.Validators.Creation;
using FluentValidation;
using LapStopApiHost.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLogLib;
using Repositories;
using RestfulApiHandler.ActionFilters;
using Services;
using Services.DataShaping;

LogManager.LoadConfiguration(
    Path.Combine(Directory.GetCurrentDirectory(), 
    "../../Infrastructures/NLogLib/NLog.config")
);

var builder = WebApplication.CreateBuilder(args);

// right ABOVE the AddControllers() method
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    // disable 400 – Bad Request responses of [ApiController] attr
    options.SuppressModelStateInvalidFilter = true;  
});


// Add services to the container.
builder.Services.AddAutoMapper(typeof(AutoMapperLib.MappingProfile));

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
    .AddApplicationPart(typeof(RestfulApiHandler.AssemblyReference).Assembly)
    .AddNewtonsoftJson();

builder.Services.AddDbContext<LapStopContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("LapStopConnection"))
);

builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddSingleton<ILogService, NLogService>();

builder.Services.AddScoped<IValidator<BrandForCreationDto>, BrandForCreationValidator>();

// Register for IDataShaper
builder.Services.AddScoped<IDataShaper<EmployeeDto>, DataShaper<EmployeeDto>>();
builder.Services.AddScoped<IDataShaper<BrandDto>, DataShaper<BrandDto>>();
builder.Services.AddScoped<IDataShaper<CustomerDto>, DataShaper<CustomerDto>>();
builder.Services.AddScoped<IDataShaper<ProductDto>, DataShaper<ProductDto>>();

// Register ActionFilter to Services
builder.Services.AddScoped<ValidationFilterAttribute>();

//Register to IOC
//builder.Services.AddResponseCaching();

builder.Services.AddHttpCacheHeaders(
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

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

// UseCors must be called before UseResponseCaching
//app.UseCors();


app.UseAuthorization();

//app.UseResponseCaching();

app.UseHttpCacheHeaders();

app.MapControllers();

app.Run();
