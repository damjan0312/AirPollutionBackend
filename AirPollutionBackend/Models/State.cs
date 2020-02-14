using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirPollutionBackend.Models
{
    public class State
    {
        public string id { get; set; }
        public string state { get; set; }
    }
}