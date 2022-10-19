using Microsoft.AspNetCore.Mvc;
using MongoApp.Api.Models;
using MongoApp.Data.Tables;
using MongoApp.Extension.Mongo.Repository;
using MongoApp.Repository.Repository.City;

namespace MongoApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GlobalMapCityController : ControllerBase
    {
        private readonly IGlobalMapCityRepository _globalMapCityRepository;
        private readonly ICacheService _cacheService;
        public GlobalMapCityController(IGlobalMapCityRepository globalMapCityRepository, ICacheService cacheService)
        {
            _globalMapCityRepository = globalMapCityRepository;
            _cacheService = cacheService;
        }




        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _globalMapCityRepository.Get();
            if (result == null)
            {
                return BadRequest("Not found");
            }

            return Ok(result.ToList());
        }

        [Route("Create")]
        [HttpPost]
        public IActionResult Create([FromBody] GlobalMapCity data)
        {
            var result = _globalMapCityRepository.AddAsync(data).Result;
            return Ok(result);
        }

        [Route("GetById")]
        [HttpPost]
        public IActionResult GetById([FromBody] string id = "")
        {
            var result = _globalMapCityRepository.GetByIdAsync(id).Result;
            return Ok(result);
        }

        [Route("AddMap")]
        [HttpGet]
        public ActionResult GetRedisServer()
        {
            List<GlobalMap> globalMapList = new List<GlobalMap>();

            string guid = Guid.NewGuid().ToString();
            for (int i = 0; i < 13455; i++)
            {
                globalMapList.Add(new GlobalMap()
                {
                    Code= guid,
                    Name= guid,
                    Id= guid,
                });
            }
            _cacheService.Add("Map", globalMapList);
            return Ok();
        }
    }
}
