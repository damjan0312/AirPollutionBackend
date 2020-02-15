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
    public class PollutionController : ApiController
    {
        [System.Web.Http.Route("api/pollution")]
        public Pollution getPollution(string cityId,string stateId)
        {
            return PollutionService.GetPollution(cityId,stateId);
        }
        [System.Web.Http.Route("api/mostPolluted")]
        public List<Pollution> getMostPollutedCities()
        {
            return PollutionService.getMostPollutedCities();
        }

        [System.Web.Http.Route("api/history")]
        public List<Pollution> getHistory(string cityId)
        {
            return PollutionService.getHistory(cityId);
        }

        [System.Web.Http.AcceptVerbs("GET", "POST","DELETE")]
        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("api/deleteHistory")]
        public void deleteHistory(string Id)
        {
            PollutionService.deleteHistory(Id);
        }
    }
}
