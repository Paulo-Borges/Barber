using Barber.API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Barber.API.Controllers
{
    
    public class DeviceController : MyFirstApiBaseController
    {
        [HttpGet]
        public IActionResult Get()
        {
            var laptop = new Laptop();

            var x = laptop.IsConnected();

            var model = laptop.GetModel();
            
            return Ok(model);
        }
    }
}
