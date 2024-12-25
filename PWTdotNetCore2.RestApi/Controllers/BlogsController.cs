using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PWTdotNetCore2.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        [HttpGet]
            public IActionResult Get()
        {
            return Ok();
        }

        [HttpPut]
            public IActionResult Edit()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Create()
        {
            return Ok();
        }

        [HttpPatch]
        public IActionResult Update()
        {
            return Ok();
        }

        [HttpDelete]
            public IActionResult Delete()
        {
            return Ok();
        }
    }
}
