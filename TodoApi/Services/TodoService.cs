using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Dtos;
using TodoApi.Models;

namespace TodoApi.Services;

public class TodoService : ITodoService
{
    private readonly TodoDbContext _dbContext;

    public TodoService(TodoDbContext dbContext)
        => _dbContext = dbContext ?? throw new ArgumentNullException($"{nameof(TodoDbContext)} dependency is missing");

    public Task<List<Todo>> GetTodoList()
        => _dbContext.Todos.ToListAsync();

    public async Task<Todo> AddTodo(AddTodoDto addTodoDto)
    {
        var todo = new Todo
        {
            Title = addTodoDto.Title,
            Description = addTodoDto.Description
        };

        await _dbContext.Todos.AddAsync(todo);
        await _dbContext.SaveChangesAsync();

        return todo;
    }

    public int FindFactorial(int row)
    {
        var factorial = 1;

        for(int i = 1; i <= row; i++)
        {
            factorial *= i;
        }

        // var factorial = Enumerable
        //     .Range(1, row)
        //     .Aggregate(1, (factorial, row) => factorial * row);

        // return factorial;

        return factorial;
    }
}
