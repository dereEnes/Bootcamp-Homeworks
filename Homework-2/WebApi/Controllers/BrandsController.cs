using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi.Models;

namespace WebApi.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        [HttpPost("add")]
        public IActionResult Add(Brand brand)
        {
            return Ok("Added");
            
        }
<<<<<<< HEAD

=======
>>>>>>> 01aae54b4e29168c8b360127d98304ae35a0b3a5
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet("getbyid")]
        public Brand Get(int id)
        {
            return new Brand { Name = "Mercedes" };
        }
       
        [HttpGet("getall")]
        public List<Brand> GetAll()
        {
            return new List<Brand>()
            {
                new Brand{ Name = "Audi" },
                new Brand{ Name = "Ford" }
            };
        }
    }
}
