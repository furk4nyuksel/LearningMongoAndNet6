using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoApp.Extension.Mongo.Repository
{
    public interface ICacheService
    {
        void Add<T>(string key, T data);
        void Remove(string key);
        void Clear();
        bool Any(string key);
        T Get<T>(string key);


    }
}
