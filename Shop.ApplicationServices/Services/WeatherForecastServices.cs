using System.Net;
using Shop.Core.Dto.OpenWeatherDtos;

namespace Shop.ApplicationServices.Services
{
    public class WeatherForecastServices
    {
        public async Task<OpenWeatherResultDto> OpenWeatherResult(OpenWeatherResultDto dto)
        {
            string idOpenWeather = "yourAPIkey";
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={dto.City}&units=metric&appid={idOpenWeather}";

            using (WebClient client = new WebClient())
            {

            }

            return dto;
        }
    }
}
