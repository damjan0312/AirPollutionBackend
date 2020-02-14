﻿using System;
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
        public List<Pollution> getPollution()
        {
            return PollutionService.GetAllPollution();
        }
    }
}
