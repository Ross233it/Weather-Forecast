using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using CommonClassLibrary.Models;

namespace WeatherForecast.CommonClassLibrary.Models{
    public class Location
    {
        [JsonPropertyName("localita")]
        public string Localita { get; set; }

        [JsonPropertyName("comune")]
        public string Comune { get; set; }

        [JsonPropertyName("quota")]
        public int Quota { get; set; }

        [JsonPropertyName("latitudine")]
        public string Latitudine { get; set; }

        [JsonPropertyName("longitudine")]
        public string Longitudine { get; set; }       
    }
}
