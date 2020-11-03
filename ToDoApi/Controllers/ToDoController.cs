using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
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
            var id = Int32.Parse(data.First(s => s.Type == ClaimTypes.NameIdentifier).Value);
            return Ok(_toDoService.GetToDos(id));
            
        }

        [HttpPut("{id}/complete")]
        public IActionResult Complete([FromRoute] int id)
        {
            _toDoService.Complete(id);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Remove([FromRoute] int id)
        {
            var claims = User.Identity as ClaimsIdentity;
            var data = claims.Claims;
            var userId = int.Parse(data.First(s => s.Type == ClaimTypes.NameIdentifier).Value);
            return Ok(_toDoService.Remove(userId, id));
        }

        [HttpPut("{id}/update")]
        public IActionResult Update([FromRoute] int id, [FromBody] ToDoUpdate todo)
        {
            
            _toDoService.UpdateTodo(id, todo);
            return Ok();
        }

        [HttpPost("")]
        public IActionResult AddTodo([FromBody] CreateTodoReq req)
        {
            var claims = User.Identity as ClaimsIdentity;
            var data = claims.Claims;
            var id = int.Parse( data.First(s => s.Type == ClaimTypes.NameIdentifier).Value);
            _toDoService.AddTodo(id, req.Title);
            return Ok();
        }

    }
}
