﻿using System.ComponentModel.DataAnnotations;

namespace TARgv22Shop.Models.OpenWeathers
{
    public class SearchCityViewModel
    {
        [Required(ErrorMessage = "You must enter a city name!")]
        [RegularExpression("^[A-z]+$", ErrorMessage = "Only text allowed!")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Enter a city name greater than 2 and lesser than 20 characters!")]
        [Display(Name = "City Name")]
        public string CityName { get; set; }
    }
}
