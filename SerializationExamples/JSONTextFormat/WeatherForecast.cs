using System.Text.Json.Serialization;

namespace SerializationExamples.JSONTextFormat
{
    public class WeatherForecast
    {
        public int Y = 10;
        [JsonPropertyName("name")]
        public int X { get; set; }
        public int TemperatureCelsius { get; set; }
        public string Summary { get; set; }

        public WeatherForecast()
        {
        }
    }
}
