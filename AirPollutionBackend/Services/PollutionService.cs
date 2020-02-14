﻿using System;
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
                p.current.weather.timestamp = doc.AsBsonDocument["current"].AsBsonDocument["weather"].AsBsonDocument["ts"].AsString;
                p.current.weather.temperature = doc.AsBsonDocument["current"].AsBsonDocument["weather"].AsBsonDocument["tp"].AsDouble.ToString() ;
                p.current.weather.pressure = doc.AsBsonDocument["current"].AsBsonDocument["weather"].AsBsonDocument["pr"].AsDouble.ToString();
                p.current.weather.humidity = doc.AsBsonDocument["current"].AsBsonDocument["weather"].AsBsonDocument["hu"].AsDouble.ToString();
                p.current.pollution.timestamp = doc.AsBsonDocument["current"].AsBsonDocument["pollution"].AsBsonDocument["ts"].AsString;
                p.current.pollution.aqius = doc.AsBsonDocument["current"].AsBsonDocument["pollution"].AsBsonDocument["aquis"].AsDouble.ToString();

                pollution.Add(p);
            }

            return pollution;
        }
    }
}