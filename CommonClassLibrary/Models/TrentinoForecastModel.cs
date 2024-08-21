using System.Text.Json.Serialization;
using System.Collections.Generic;
using CommonClassLibrary.Models;

namespace WeatherForecast.CommonClassLibrary.Models { 
    public class TrentinoForecastModel{
        public string fontedacitare { get; set; }
        public string codiceipatitolare { get; set; }
        
        [JsonPropertyName("nome-titolare")]
        public string nometitolare { get; set; }
        public string codiceipaeditore { get; set; }
        public string nomeeditore { get; set; }
        public string dataPubblicazione { get; set; }
        public int    idPrevisione { get; set; }
        public string evoluzione { get; set; }
        public string evoluzioneBreve { get; set; }
        public object[] AllerteList { get; set; }
        public Previsione[] previsione { get; set; }       
    }
}
