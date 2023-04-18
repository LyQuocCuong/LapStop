using Contracts.ILog;
using Contracts.IServices;
using DTO.Output;
using Microsoft.AspNetCore.Mvc;

namespace LapStopRestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogService _logger;
        private readonly IServiceManager _serviceManager;

        public WeatherForecastController(ILogService logger, IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public List<EmployeeRoleDto> Get()
        {
            _logger.LogInfo("Hello");
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = Random.Shared.Next(-20, 55),
            //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            //})
            //.ToArray();
            return _serviceManager.EmployeeRole.GetAll();
        }
    }
}