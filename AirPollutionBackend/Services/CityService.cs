using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MongoDB.Driver;
using MongoDB.Bson;
using AirPollutionBackend.Models;

namespace AirPollutionBackend.Services
{
    public static class  CityService
    {
        public static List<City> GetAllCities()
        {
            var connectionString = "mongodb://localhost/?safe=true";

            var client = new MongoClient(connectionString);
            var db = client.GetDatabase("airpollutionDB");

            var collection = db.GetCollection<BsonDocument>("city");

            List<City> cities = new List<City>();

            var documents = collection.Find(new BsonDocument()).ToList();

            foreach (BsonDocument doc in documents)
            {
                City c = new City();
                c.city = doc.AsBsonDocument["city"].ToString();
                c.id = doc.AsBsonDocument["_id"].AsObjectId.ToString();
                c.stateId = doc.AsBsonDocument["stateId"].AsObjectId.ToString();
                cities.Add(c);
            }

            return cities;
        }

        public static List<State> GetAllStates()
        {
            var connectionString = "mongodb://localhost/?safe=true";

            var client = new MongoClient(connectionString);
            var db = client.GetDatabase("airpollutionDB");

            var collection = db.GetCollection<BsonDocument>("state");

            List<State> states = new List<State>();

            var documents = collection.Find(new BsonDocument()).ToList();

            foreach (BsonDocument doc in documents)
            {
                State s = new State();
                s.id = doc.AsBsonDocument["_id"].AsObjectId.ToString();
                s.state = doc.AsBsonDocument["state"].AsString;
                states.Add(s);
            }

            return states;
        }
    }
}