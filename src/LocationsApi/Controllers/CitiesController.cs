using System;
using LocationsApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LocationsApi.Controllers
{
    [Route("api/cities")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private List<City> cities;

        public CitiesController()
        {
            cities = new List<City>()
            {
                new City("Delhi", "DL"),
                new City("London", "LON"),
                new City("New York", "NY"),
                new City("Wien", "WN"),
            };
        }
        [HttpGet]
        public IList<City> GetCities()
        {
            return cities;
        }

        [HttpGet("{cityCode}")]
        public City GetCity(string cityCode)
        {
            var city = cities.FirstOrDefault(b =>
                b.CityCode.Equals(cityCode, StringComparison.InvariantCultureIgnoreCase));
            return city ?? new City("NA", "NA");
        }

        [HttpPost]
        public ActionResult AddCity(string cityCode, string cityName)
        {
            cities.Add(new City(cityCode, cityName));
            return Created("", "");
        }
    }
}
