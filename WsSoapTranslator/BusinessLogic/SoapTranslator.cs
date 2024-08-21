using WeatherForecast.CommonClassLibrary.Models;
using WsSoapTranslator.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Reflection;

namespace WsSoapTranslator.BusinessLogic
{
    [ServiceContract]

    public interface ISoapTranslator
    {
        [OperationContract]
        TrentinoForecastModel GetTrentinoForecast(string location = "");

        [OperationContract]
        TrentinoForecastModel GetTrentinoForecastByDate(DateTime filterDate, string location = "");

    }

    public class SoapTranslator : ISoapTranslator
    {

        public TrentinoForecastModel GetTrentinoForecast(string location = "")
        {
            if (location == "")
                location = "TRENTO";
            string url = $"https://www.meteotrentino.it/protcivtn-meteo/api/front/previsioneOpenDataLocalita?localita={Uri.EscapeDataString(location)}";

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = client.GetAsync(url).Result)
                {
                    using (HttpContent content = response.Content)
                    {
                        string result = content.ReadAsStringAsync().Result;
                        TrentinoForecastModel model = JsonConvert.DeserializeObject<TrentinoForecastModel>(result);
                        return model;
                    }
                }
            }

        }

        public TrentinoForecastModel GetTrentinoForecastByDate(DateTime filterDate, string location = "")
        {
            TrentinoForecastModel resultModel = GetTrentinoForecast(location);
            if (filterDate != null)
            {
                foreach (var previsione in resultModel.previsione)
                {
                    previsione.giorni = previsione.giorni
                        .Where(g => DateTime.Parse(g.giorno) == filterDate)
                        .ToArray();
                }
            }
            return resultModel;
        }
    }
}