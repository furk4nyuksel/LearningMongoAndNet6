using Microsoft.Extensions.Options;
using MongoApp.Data.Tables;
using MongoApp.Repository.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoApp.Repository.Repository.City
{
    public  class GlobalMapCityRepository : MongoDbRepositoryBase<GlobalMapCity>, IGlobalMapCityRepository
    {
        public GlobalMapCityRepository(IOptions<MongoDbSettings> options) : base(options)
        {
        }
    }
}
