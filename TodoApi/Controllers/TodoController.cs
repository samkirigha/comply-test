using System.Collections.Concurrent;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Dtos;
using TodoApi.Models;
using TodoApi.Services;

namespace TodoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private readonly ITodoService _todoService;

    public TodoController(ITodoService todoService)
        => _todoService = todoService ?? throw new ArgumentNullException($"{nameof(ITodoService)} dependency is missing");

    [HttpGet]
    public async Task<ActionResult> Index()
    {
        var todos = (await _todoService.GetTodoList())
            .Select((todo, index) => new TodoDetailsDto
            {
                Id = todo.Id,
                Row = index,
                Title = todo.Title,
                Description = todo.Description
            });

        return Ok(todos);
    }

    [HttpPost]
    public async Task<ActionResult> Create(AddTodoDto addTodoDto)
    {
        var todo = await _todoService.AddTodo(addTodoDto);

        return CreatedAtRoute(default, todo);
    }

    [HttpGet("Factorial")]
    public async Task<ActionResult> Factorial()
    {
        var factorials = new ConcurrentBag<TodoDetailsDto>();
        var todos = (await _todoService.GetTodoList())
            .Select((todo, index) => new TodoDetailsDto
            {
                Id = todo.Id,
                Row = index,
                Title = todo.Title,
                Description = todo.Description
            });

        Parallel.ForEach(todos, todo =>
        {
            var row = todo.Row.Value;
            todo.Factorial = _todoService.FindFactorial(row);

            factorials.Add(todo);
        });

        return Ok(factorials);
    }
}
