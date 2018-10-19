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
        [HttpPut]
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
            return Ok();
        }
        // Post api/User
        [HttpPost]
        public IActionResult Login([FromBody]UserViewModel request)
        {
            var user = _context.Users.FirstOrDefault(x => x.Username == request.Username.ToLower());
            
            if(user != null)
            {
                return Ok();
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}