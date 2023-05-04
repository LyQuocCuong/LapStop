using Azure;
using Contracts.ILog;
using Contracts.IRepositories;
using Contracts.IServices;
using Entities.Context;
using LapStopApiHost.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLogLib;
using Repositories;
using Services;

LogManager.LoadConfiguration(
    Path.Combine(Directory.GetCurrentDirectory(), 
    "../../Infrastructures/NLogLib/NLog.config")
);

var builder = WebApplication.CreateBuilder(args);

// right ABOVE the AddControllers() method
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;  // disable 400 – Bad Request responses.
});


// Add services to the container.
builder.Services.AddAutoMapper(typeof(AutoMapperLib.MappingProfile));
builder.Services.AddControllers()
    .AddApplicationPart(typeof(RestfulApiHandler.AssemblyReference).Assembly)
    .AddNewtonsoftJson();
builder.Services.AddDbContext<LapStopContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("LapStopConnection"))
);
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddSingleton<ILogService, NLogService>();


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

app.UseAuthorization();

app.MapControllers();

app.Run();
