﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirPollutionBackend.Models
{
    public class Pollution
    {
        public string id { get; set; }
        public string cityId { get; set; }
        public string stateId { get; set; }
        public string current { get; set; }
    }
}