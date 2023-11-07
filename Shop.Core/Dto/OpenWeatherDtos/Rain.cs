using System.Text.Json.Serialization;

namespace Shop.Core.Dto.OpenWeatherDtos
{
    public class Rain
    {
        [JsonPropertyName("1h")]
        public double _1h { get; set; }

        [JsonPropertyName("3h")]
        public double _3h { get; set; }
    }
}
