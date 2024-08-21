using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using WeatherForecast.CommonClassLibrary.Models;
using Microsoft.Extensions.Logging;


namespace WeatherForecast.Controllers{
    public class TrentinoForecastController : Controller{

        private readonly HttpClient _httpClient;
        private readonly ILogger<TrentinoForecastController> _logger;

        public TrentinoForecastController(HttpClient httpClient, ILogger<TrentinoForecastController> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        [HttpGet("trentino-forecast")]
        public async Task<IActionResult> GetExternalWeather(string location)
        {    _logger.LogInformation("metodo lanciato");
            if (string.IsNullOrEmpty(location))
            {
                location = "TRENTO";
            }
            var url = $"https://www.meteotrentino.it/protcivtn-meteo/api/front/previsioneOpenDataLocalita?localita={Uri.EscapeDataString(location)}";
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {

                var data = await response.Content.ReadAsStringAsync();
                //_logger.LogInformation("Dati ricevuti: {data}", data);

                var deserialized = JsonSerializer.Deserialize<TrentinoForecastModel>(data, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                //_logger.LogInformation("Dati deserializzati: {deserialized}", deserialized);
               
                return View(deserialized);                
            }
            else            
                return StatusCode((int)response.StatusCode, "Error fetching data from external API");
            }
        }
    }

