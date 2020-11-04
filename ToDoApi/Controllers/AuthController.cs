using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToDoApi.Interfaces;
using ToDoApi.Models;
using ToDo.DataBase.Model;

namespace ToDoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService; 
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AuthController(IAuthService authService, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _authService = authService;
            _userManager = userManager;
            _signInManager = signInManager;
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
        public async Task<IActionResult> RegisterAsync(RegisterViewModel model)
        {
            
                var user = new IdentityUser { UserName = model.Name, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return Ok();
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }

                    return await Task.FromResult(StatusCode(500));
                }
            
          
        }
    }
}
