using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using ToDoApi.Interfaces;
using ToDoApi.Models;

namespace ToDoApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]

    public class ToDoController : ControllerBase
    {
        private readonly ITodoService _toDoService;

        public ToDoController(ITodoService toDoService)
        {
            _toDoService = toDoService;
        }

        [HttpGet("all")]
        public IActionResult GetDoTos()
        {
            var claims = User.Identity as ClaimsIdentity;
            var data = claims.Claims;
            var email = data.First(s => s.Type == ClaimTypes.Email).Value;
            return Ok(_toDoService.GetToDos(email));
        }

        [HttpPut("{id}/complete")]
        public IActionResult Complete([FromRoute] int id)
        {
            var claims = User.Identity as ClaimsIdentity;
            var data = claims.Claims;
            var email = data.First(s => s.Type == ClaimTypes.Email).Value;
            _toDoService.Complete(email, id);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Remove([FromRoute] int id)
        {
            var claims = User.Identity as ClaimsIdentity;
            var data = claims.Claims;
            var email = data.First(s => s.Type == ClaimTypes.Email).Value;
            _toDoService.Remove(email,id);
            return Ok();
        }

        [HttpPut("{id}/update")]
        public IActionResult Update([FromRoute] int id, [FromBody] ToDoUpdate todo)
        {
            var claims = User.Identity as ClaimsIdentity;
            var data = claims.Claims;
            var email = data.First(s => s.Type == ClaimTypes.Email).Value;
            _toDoService.UpdateTodo(email, id, todo);
            return Ok();
        }

        [HttpPost("")]
        public IActionResult AddTodo([FromBody] CreateTodoReq req)
        {
            var claims = User.Identity as ClaimsIdentity;
            var data = claims.Claims;
            var email = data.First(s => s.Type == ClaimTypes.Email).Value;
            _toDoService.AddTodo(email, req.Title);
            return Ok();
        }

    }
}
