using Newtonsoft.Json;

namespace WeatherApp.Models
{
    public class Weather
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("main")]
        public string Main { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        public string IconURL => $"https://openweathermap.org/img/wn/{Icon}@4x.png";
    }


}
