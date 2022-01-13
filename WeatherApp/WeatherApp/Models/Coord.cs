using Newtonsoft.Json;

namespace WeatherApp.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Coord
    {
        [JsonProperty("lon")]
        public int Lon { get; set; }

        [JsonProperty("lat")]
        public int Lat { get; set; }
    }


}
