using GraphQL;
using GraphQL.Client.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLVue.Web.Controllers
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
        private readonly GraphQLHttpClient _httpClient;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, GraphQLHttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            var personAndFilmsRequest = new GraphQLRequest
            {
                Query = @"
			    {
			         event(eventId:1){
                            eventId
                            eventName
                            eventDate
                            speaker
                          }
			    }",
                OperationName = null,
                Variables = null
            };

            try
            {
                var graphQLResponse = await _httpClient.SendQueryAsync<object>(personAndFilmsRequest);
            }
            catch(Exception ex)
            {

            }

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
