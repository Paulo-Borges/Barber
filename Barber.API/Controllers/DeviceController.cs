using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Barber.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : MyFirstApiBaseController
    {
        [HttpGet]
        public IActionResult Get()
        {
            
            return Ok("laptop");
        }
    }
}
