using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using InMemory.Models.DbEntities;

namespace InMemory.Controllers
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
        private MyContext _context;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, MyContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("customers")]
        public async Task<IActionResult> GetDatas(){
            await Task.CompletedTask;
            return Ok(_context.Customers.ToList());
        }

        [HttpPost("customer")]
        public async Task<IActionResult> PostData([FromBody] Customer body){
            _context.Customers.Add(body);
            _context.SaveChanges();
            await Task.CompletedTask;
            return Ok();
        }
    }
}
