using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 
    {
        "coord": {
            "lon": 24.7535,
            "lat": 59.437
        },
        "weather": [
            {
                "id": 803,
                "main": "Clouds",
                "description": "broken clouds",
                "icon": "04d"
            }
        ],
        "base": "stations",
        "main": {
            "temp": 281.35,
            "feels_like": 279.15,
            "temp_min": 280.11,
            "temp_max": 282.79,
            "pressure": 998,
            "humidity": 97
        },
        "visibility": 10000,
        "wind": {
            "speed": 3.6,
            "deg": 240
        },
        "clouds": {
            "all": 75
        },
        "dt": 1699342327,
        "sys": {
            "type": 1,
            "id": 1330,
            "country": "EE",
            "sunrise": 1699336469,
            "sunset": 1699366489
        },
        "timezone": 7200,
        "id": 588409,
        "name": "Tallinn",
        "cod": 200
    }
 
 */

namespace Shop.Core.Dto.OpenWeatherDtos
{
    public class OpenWeatherResultDto
    {
        public string City { get; set; }

        public Coord Coord { get; set; }

        public double WeatherId { get; set; }
        public string Main { get; set; }

        public int Humidity { get; set; }

        public Sys Sys { get; set; }
    }
}
