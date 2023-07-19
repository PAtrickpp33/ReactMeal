using MongoDB.Driver;
using MongoDB.Bson;
using System;

namespace Backend.Data 
{
    public class ReactMealDB
    {
        private readonly IMongoClient _client;
        private const string ConnectionUri = "mongodb+srv://root:123456Abc@reactmeal.ik178gg.mongodb.net/?retryWrites=true&w=majority";

        public ReactMealDB()
        {
            var settings = MongoClientSettings.FromConnectionString(ConnectionUri);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            _client = new MongoClient(settings);
        }

        public void TestConnection()
        {
            try
            {
                var result = _client.GetDatabase("admin").RunCommand<BsonDocument>(new BsonDocument("ping", 1));
                Console.WriteLine("Pinged your deployment. You successfully connected to MongoDB!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}


