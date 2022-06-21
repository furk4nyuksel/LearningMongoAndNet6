using MongoApp.Data.Infrastructure;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoApp.Data.Tables
{
    public class GlobalMapCity:BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string x { get; set; }
    }
}
