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
        public static List<Pollution> GetAllPollution()
        {
            var connectionString = "mongodb://localhost/?safe=true";

            var client = new MongoClient(connectionString);
            var db = client.GetDatabase("airpollutionDB");

            var collection = db.GetCollection<BsonDocument>("pollution");

            List<Pollution> pollution = new List<Pollution>();

            var documents = collection.Find(new BsonDocument()).ToList();

            foreach (BsonDocument doc in documents)
            {
                Pollution p = new Pollution();
                p.id = doc.AsBsonDocument["_id"].AsObjectId.ToString();
                p.cityId = doc.AsBsonDocument["cityId"].AsObjectId.ToString();
                p.stateId = doc.AsBsonDocument["stateId"].AsObjectId.ToString();
                p.current = doc.AsBsonDocument["current"].ToJson();
                pollution.Add(p);
            }

            return pollution;
        }
    }
}