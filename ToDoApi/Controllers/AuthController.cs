using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoApi.Interfaces;
using ToDoApi.Models;

namespace ToDoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        
        public IActionResult Login([FromBody] LoginData data)
        {
            var response = _authService.Login(data);
            if (response == null)
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }
            return Ok(response);
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] LoginData data)
        {
            return Ok();

        }
    }
}
