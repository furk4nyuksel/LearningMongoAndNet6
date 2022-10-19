using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MongoApp.Extension.Mongo.Repository
{
    public class RedisCacheManager : ICacheService
    {
        private readonly IRedisConnectionFactory _connection;
        private readonly IDatabase _database;

        public RedisCacheManager(IRedisConnectionFactory connection)
        {
            _connection = connection;
            _database = connection.GetDatabase(0);
        }

        public void Add<T>(string key, T data)
        {
            string jsonData = JsonConvert.SerializeObject(data);
            _database.StringSet(key, jsonData);
        }

        public bool Any(string key)
        {
            return _database.KeyExists(key);
        }

        public void Clear()
        {
            _database.Multiplexer.GetServer("http:localhost:49156").FlushDatabase();

        }

        public T Get<T>(string key)
        {

            if (!Any(key))
            {
                return default;
            }
            else
            {
                string stringData = _database.StringGet(key);
                T jsondata = JsonConvert.DeserializeObject<T>(stringData);
                return jsondata;
            }
        }

        public void Remove(string key)
        {
            _database.KeyDelete(key);
        }

 
    }
}
