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
    public class PollutionService
    {
        public static Pollution GetPollution(string cityId,string stateId)
        {
            var connectionString = "mongodb://localhost/?safe=true";

            var client = new MongoClient(connectionString);
            var db = client.GetDatabase("airpollutionDB");

            var collection = db.GetCollection<BsonDocument>("pollution");

            var builder = Builders<BsonDocument>.Filter;

            var filter = builder.Eq("cityId", ObjectId.Parse(cityId)) & builder.Eq("stateId", ObjectId.Parse(stateId));
            
            var documents = collection.Find(filter).ToList();

            foreach (BsonDocument doc in documents)
            {
                Pollution p = new Pollution();
                p.id = doc.AsBsonDocument["_id"].AsObjectId.ToString();
                p.cityId = doc.AsBsonDocument["cityId"].AsObjectId.ToString();
                p.stateId = doc.AsBsonDocument["stateId"].AsObjectId.ToString();
                p.current.weather.timestamp = doc.AsBsonDocument["current"].AsBsonDocument["weather"].AsBsonDocument["ts"].AsString;
                p.current.weather.temperature = doc.AsBsonDocument["current"].AsBsonDocument["weather"].AsBsonDocument["tp"].AsDouble.ToString() ;
                p.current.weather.pressure = doc.AsBsonDocument["current"].AsBsonDocument["weather"].AsBsonDocument["pr"].AsDouble.ToString();
                p.current.weather.humidity = doc.AsBsonDocument["current"].AsBsonDocument["weather"].AsBsonDocument["hu"].AsDouble.ToString();
                p.current.pollution.timestamp = doc.AsBsonDocument["current"].AsBsonDocument["pollution"].AsBsonDocument["ts"].AsString;
                p.current.pollution.aqius = doc.AsBsonDocument["current"].AsBsonDocument["pollution"].AsBsonDocument["aqius"].AsDouble.ToString();

                return p;
            }

            return null;
            
        }

        public static List<Pollution> getMostPollutedCities()
        {
            var connectionString = "mongodb://localhost/?safe=true";

            var client = new MongoClient(connectionString);
            var db = client.GetDatabase("airpollutionDB");

            var collection = db.GetCollection<BsonDocument>("pollution");

            List<Pollution> pollutions = new List<Pollution>();

            var documents = collection.Find((new BsonDocument())).Limit(5).Sort("{aquis:1}").ForEachAsync((doc) =>
            {
                Pollution p = new Pollution();
                p.id = doc.AsBsonDocument["_id"].AsObjectId.ToString();
                p.cityId = doc.AsBsonDocument["cityId"].AsObjectId.ToString();
                p.stateId = doc.AsBsonDocument["stateId"].AsObjectId.ToString();
                p.current.weather.timestamp = doc.AsBsonDocument["current"].AsBsonDocument["weather"].AsBsonDocument["ts"].AsString;
                p.current.weather.temperature = doc.AsBsonDocument["current"].AsBsonDocument["weather"].AsBsonDocument["tp"].AsDouble.ToString();
                p.current.weather.pressure = doc.AsBsonDocument["current"].AsBsonDocument["weather"].AsBsonDocument["pr"].AsDouble.ToString();
                p.current.weather.humidity = doc.AsBsonDocument["current"].AsBsonDocument["weather"].AsBsonDocument["hu"].AsDouble.ToString();
                p.current.pollution.timestamp = doc.AsBsonDocument["current"].AsBsonDocument["pollution"].AsBsonDocument["ts"].AsString;
                p.current.pollution.aqius = doc.AsBsonDocument["current"].AsBsonDocument["pollution"].AsBsonDocument["aqius"].AsDouble.ToString();

                pollutions.Add(p);
            });
            
            return pollutions;

        }

        public static List<Pollution> getHistory(string cityId)
        {
            var connectionString = "mongodb://localhost/?safe=true";

            var client = new MongoClient(connectionString);
            var db = client.GetDatabase("airpollutionDB");

            var collection = db.GetCollection<BsonDocument>("pollutionHistory");

            var builder = Builders<BsonDocument>.Filter;

            var filter = builder.Eq("cityId", ObjectId.Parse(cityId));

            var documents = collection.Find(filter).ToList();

            List<Pollution> pollutions = new List<Pollution>();

            foreach (BsonDocument doc in documents)
            {
                Pollution p = new Pollution();
                p.id = doc.AsBsonDocument["_id"].AsObjectId.ToString();
                p.cityId = doc.AsBsonDocument["cityId"].AsObjectId.ToString();
                p.stateId = doc.AsBsonDocument["stateId"].AsObjectId.ToString();
                p.current.weather.timestamp = doc.AsBsonDocument["current"].AsBsonDocument["weather"].AsBsonDocument["ts"].AsString;
                p.current.weather.temperature = doc.AsBsonDocument["current"].AsBsonDocument["weather"].AsBsonDocument["tp"].AsDouble.ToString();
                p.current.weather.pressure = doc.AsBsonDocument["current"].AsBsonDocument["weather"].AsBsonDocument["pr"].AsDouble.ToString();
                p.current.weather.humidity = doc.AsBsonDocument["current"].AsBsonDocument["weather"].AsBsonDocument["hu"].AsDouble.ToString();
                p.current.pollution.timestamp = doc.AsBsonDocument["current"].AsBsonDocument["pollution"].AsBsonDocument["ts"].AsString;
                p.current.pollution.aqius = doc.AsBsonDocument["current"].AsBsonDocument["pollution"].AsBsonDocument["aqius"].AsDouble.ToString();

                pollutions.Add(p);
            }

            return pollutions;

        }
    }
}