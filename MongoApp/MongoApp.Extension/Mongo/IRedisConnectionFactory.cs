using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoApp.Extension.Mongo
{
    public interface IRedisConnectionFactory
    {
        ConnectionMultiplexer Connection();
        IDatabase GetDatabase(int db);
    }
}
