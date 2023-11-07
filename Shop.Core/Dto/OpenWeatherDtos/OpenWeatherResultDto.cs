namespace Shop.Core.Dto.OpenWeatherDtos
{
    public class OpenWeatherResultDto
    {
        public string City { get; set; }
        public double Lon { get; set; }
        public double Lat { get; set; }
        public double WeatherId { get; set; }
        public string Main { get; set; }
        public int Humidity { get; set; }
        public double Temp { get; set; }
        public double FeelsLike { get; set; }
        public int Pressure { get; set; }
        public double WindSpeed { get; set; }
        public string Description { get; set; }
    }
}
