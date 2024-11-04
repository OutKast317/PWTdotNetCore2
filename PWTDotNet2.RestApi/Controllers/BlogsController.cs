using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PWTDotNet2.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetBlogs()
        {
            return Ok(new {Message = "GetBlogs"});
        }

        [HttpPost]
        public IActionResult CreateBlogs()
        {
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateBlogs() 
        {
            return Ok();
        }

        [HttpPatch]
        public IActionResult PatchBlog() 
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteBlog() 
        { 
            return Ok();
        }
    }
}
