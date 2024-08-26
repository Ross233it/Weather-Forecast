using System.Text.Json.Serialization;
using System.Collections.Generic;
using CommonClassLibrary.Models;

namespace WeatherForecast.CommonClassLibrary.Models
{
    public class TrentinoLocations{

                [JsonPropertyName("localita")]
                public Location[] Locations { get; set; }
    }
}
