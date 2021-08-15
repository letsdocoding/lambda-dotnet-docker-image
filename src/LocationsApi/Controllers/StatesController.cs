using LocationsApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocationsApi.Controllers
{
    [Route("api/states")]
    [ApiController]
    public class StatesController : ControllerBase
    {
        private List<State> states;

        public StatesController()
        {
            states = new List<State>()
            {
                new State("California", "CA"),
                new State("Sydney", "SYD"),
                new State("Los Angeles", "LA"),
            };
        }
        [HttpGet]
        public IList<State> GetCities()
        {
            return states;
        }

        [HttpGet("{cityCode}")]
        public State GetCity(string cityCode)
        {
            var city = states.FirstOrDefault(b =>
                b.StateCode.Equals(cityCode, StringComparison.InvariantCultureIgnoreCase));
            return city ?? new State("NA", "NA");
        }

        [HttpPost]
        public ActionResult AddCity(string cityCode, string cityName)
        {
            states.Add(new State(cityCode, cityName));
            return Created("", "");
        }
    }
}
