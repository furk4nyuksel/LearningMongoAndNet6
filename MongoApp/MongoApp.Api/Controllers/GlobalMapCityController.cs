using Microsoft.AspNetCore.Mvc;
using MongoApp.Data.Tables;
using MongoApp.Repository.Repository.City;

namespace MongoApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GlobalMapCityController : ControllerBase
    {
        private readonly IGlobalMapCityRepository _globalMapCityRepository;

        public GlobalMapCityController(IGlobalMapCityRepository globalMapCityRepository)
        {
            _globalMapCityRepository = globalMapCityRepository;
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
        public IActionResult GetById([FromBody] string id="")
        {
            var result = _globalMapCityRepository.GetByIdAsync(id).Result;
            return Ok(result);
        }
    }
}
