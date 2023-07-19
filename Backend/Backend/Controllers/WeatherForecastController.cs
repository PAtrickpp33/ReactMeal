using Backend.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ReactMealDB _reactMealDB;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ReactMealDB reactMealDB)
        {
            _logger = logger;
            _reactMealDB = reactMealDB;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("test-connection")]
        public IActionResult TestConnection()
        {
            try
            {
                _reactMealDB.TestConnection();
                return Ok("Successfully connected to MongoDB!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error testing MongoDB connection");
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
