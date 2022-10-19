using MongoApp.Extension.Mongo;
using MongoApp.Extension.Mongo.Repository;
using MongoApp.Repository.Repository.City;
using MongoApp.Repository.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IRedisConnectionFactory, RedisConnectionFactory>();
builder.Services.AddSingleton<ICacheService, RedisCacheManager>();

IConfiguration configuration = new ConfigurationBuilder()
   .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
   .AddEnvironmentVariables()
   .AddCommandLine(args)
   .Build();

builder.Services.Configure<MongoDbSettings>(options =>
{
    options.ConnectionString = configuration
        .GetSection(nameof(MongoDbSettings) + ":" + MongoDbSettings.ConnectionStringValue).Value;
    options.Database = configuration
        .GetSection(nameof(MongoDbSettings) + ":" + MongoDbSettings.DatabaseValue).Value;
    options.RedisCache = configuration
    .GetSection(nameof(MongoDbSettings) + ":" + MongoDbSettings.RedisCacheValue).Value;
});


builder.Services.AddSingleton<IGlobalMapCityRepository, GlobalMapCityRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
