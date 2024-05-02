using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewsWebAppAPI.Models;
using NewsWebAppAPI.ModelView;
using NewsWebAppAPI.Services;
using static NewsWebAppAPI.Models.User;

namespace NewsWebAppAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/values
        [HttpGet("/all")]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<User?> Get(int id)
        {
            var user = _userService.GetUserById(id);
            return user;
        }
    

        // POST api/values
        [HttpPost("register")]
        public  ActionResult<string> RegisterUser(UserModelView newUser)
        {
            try
            {
                _userService.register(newUser);
                return Ok("đã thêm thành công" );
            }
            catch (Exception ex)
            {
                return BadRequest($"Registration failed: {ex.Message}");
            }
        }
        
        [HttpPost("login")]
        public ActionResult<string> Login(string email, string password)
        {
            try
            {
                 _userService.Login(email, password);
                 return Ok("đăng nhập thành công");
            }
            catch (Exception ex)
            {
                return BadRequest($"Login failed: {ex.Message}");
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

