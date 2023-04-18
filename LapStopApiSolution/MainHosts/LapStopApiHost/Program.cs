using Contracts.ILog;
using Contracts.IRepositories;
using Contracts.IServices;
using Entities.Context;
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

// Add services to the container.
builder.Services.AddControllers();
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
