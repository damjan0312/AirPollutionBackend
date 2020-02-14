using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirPollutionBackend.Models
{
    public class Current
    {
        public Weather weather { get; set; }
        public AirPollution pollution { get; set; }

        public Current()
        {
            weather = new Weather();
            pollution = new AirPollution();
        }
    }

    public class Weather
    {
        public string timestamp { get; set; }
        public string temperature { get; set; }
        public string pressure { get; set; }
        public string humidity { get; set; }
    }

    public class AirPollution
    {
        public string timestamp { get; set; }
        public string aqius { get; set; }
    }
}