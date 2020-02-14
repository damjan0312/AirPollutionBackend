using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AirPollutionBackend.Services;
using AirPollutionBackend.Models;

namespace AirPollutionBackend.Controllers
{
    public class CityController : ApiController
    {
        [System.Web.Http.Route("api/cities")]
        public List<City> GetCities()
        {
            return CityService.GetAllCities();
        }

        [System.Web.Http.Route("api/states")]
        public List<State> GetStates()
        {
            return CityService.GetAllStates();
        }
    }
}
