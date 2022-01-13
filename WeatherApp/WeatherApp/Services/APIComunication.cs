using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Services
{
    public class APIComunication
    {
        public static string BaseURL = "https://api.openweathermap.org/data/2.5/weather?";
        public static async  Task<Models.WeatherModel> GetWeatherAsync(string EndURL)
        {
            using (var c = new HttpClient())
            {
                HttpClient client = new HttpClient(); 

                var response = await client.GetAsync(new Uri(BaseURL + EndURL));

                Models.WeatherModel Items = new Models.WeatherModel();
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    Items = JsonConvert.DeserializeObject<Models.WeatherModel>(content);
                }

                return Items;
            }
        }
    }
}
