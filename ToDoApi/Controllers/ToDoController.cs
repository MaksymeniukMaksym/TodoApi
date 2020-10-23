using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ToDoApi.Models;
using ToDoApi.Services;

namespace ToDoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController: ControllerBase
    {
        private readonly IToDoService _toDoService;

        public ToDoController(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        [HttpGet("all")]
        public IActionResult GetDoTos ()
        {
            return Ok(_toDoService.GetToDos());
        }

        [HttpPut("{id}/complete")]
        public IActionResult Complete ([FromRoute] int id)
        {
            _toDoService.Complete(id);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Remove([FromRoute] int id)
        {
            _toDoService.Remove(id);
            return Ok();
        }

        [HttpPut("{id}/update")]
        public IActionResult Update([FromRoute] int id, [FromBody] ToDoUpdate todo)
        {
            _toDoService.UpdateTodo(id,todo);
            return Ok();
        }

        [HttpPost("")]
        public IActionResult AddTodo([FromBody] CreateTodoReq req)
        {
            _toDoService.AddTodo(req.Title);
            return Ok();
        }

    }
}
