using Newtonsoft.Json;

namespace WeatherApp.Models
{
    public class Clouds
    {
        [JsonProperty("all")]
        public int All { get; set; }
    }


}
