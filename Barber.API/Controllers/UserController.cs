using Barber.API.Communication.Requests;
using Barber.API.Communication.Responses;
using Barber.API.DataContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Barber.API.Controllers
{
    
    public class UserController : MyFirstApiBaseController
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult GetById([FromHeader] int id)
        {
            var response = new User
            {
                Id = 1,
                Age = 54,
                Name = "Borges"
            };
            
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(RequestRegisterUserJson), StatusCodes.Status201Created)]
        public IActionResult Create([FromBody]RequestRegisterUserJson request)
        {

            var response = new ResponseRegisterUserJson
            {
                Id = 1,
                Name = request.Name
            };
            return Created(string.Empty, response);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Update([FromBody] RequestUpdateUserProfileJson request)
        {

            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Delete()
        {

            return NoContent();
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<User>), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var response = new List<User>
            {
                new User
                {
                    Id = 1,
                    Age = 54,
                    Name = "Borges"
                },
                new User
                {
                    Id = 2,
                    Age = 30,
                    Name = "John"
                }
            };
            return Ok(response);
        }

        [HttpPut("change-password")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult ChangePassword([FromBody] RequestChangePasswordjson request)
        {
            return NoContent();
        }
    }
}
