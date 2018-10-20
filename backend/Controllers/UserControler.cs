using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VugleBE.Context;
using VugleBE.Context.Models;
using VugleBE.ViewModels;

namespace VugleBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly VugleContext _context;
        public UserController(VugleContext context)
        {
            _context = context;
        }
        // PUT api/User
        /// <summary>
        /// Registers User in database
        /// </summary>
        /// <response code="204">User succesfully created in database</response>
        /// <response code="400">User with current username already exists</response>      
        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Register([FromBody]UserViewModel request)
        {
            if(_context.Users.FirstOrDefault(x => x.Username == request.Username.ToLower()) != null)
            {
                return BadRequest();
            }
            _context.Users.Add( new User
            {
               Username = request.Username.ToLower(),
               Password = request.Password 
            });
            _context.SaveChanges();
            return NoContent();
        }
        // Post api/User
        /// <summary>
        /// Checks if User exists in database
        /// </summary>
        /// <response code="204">User exist in database</response>
        /// <response code="401">User does not exist in database</response>      
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(401)]
        public IActionResult Login([FromBody]UserViewModel request)
        {
            var user = _context.Users.FirstOrDefault(x => x.Username == request.Username.ToLower());
            
            if(user != null)
            {
                if(user.Password == request.Password)
                {
                    return NoContent();
                }
                return Unauthorized();
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}