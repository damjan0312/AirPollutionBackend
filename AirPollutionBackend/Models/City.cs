using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirPollutionBackend.Models
{
    public class City
    {
        public string id { get; set; }
        public string city { get; set; }
        public string stateId { get; set; }
    }
}