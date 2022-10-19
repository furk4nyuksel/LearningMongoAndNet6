using Microsoft.Extensions.Options;
using MongoApp.Repository.Settings;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoApp.Extension.Mongo
{
    public class RedisConnectionFactory : IRedisConnectionFactory
    {
        private readonly Lazy<ConnectionMultiplexer> _connection;
        private readonly MongoDbSettings settings;
        public RedisConnectionFactory(IOptions<MongoDbSettings> options)
        {
            _connection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(options.Value.RedisCache));
        }


        public ConnectionMultiplexer Connection()
        {
            return _connection.Value;
        }

        public IDatabase GetDatabase(int db=0)
        {
            return _connection.Value.GetDatabase(db);
        }
    }
}
