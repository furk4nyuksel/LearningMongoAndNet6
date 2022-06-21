// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;
using MongoApp.Repository.Settings;

IConfiguration configuration=new 

Console.WriteLine("Hello, World!");


MongoDbSettings mongoDbSettings = new MongoDbSettings()
{
    ConnectionString = configuration.GetSection(nameof(MongoDbSettings) + ":" + MongoDbSettings.ConnectionStringValue).Value,
     Database= configuration.GetSection(nameof(MongoDbSettings) + ":" + MongoDbSettings.DatabaseValue).Value
};

