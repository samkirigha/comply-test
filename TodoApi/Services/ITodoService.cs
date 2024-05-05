using TodoApi.Dtos;
using TodoApi.Models;

namespace TodoApi.Services;

public interface ITodoService
{
    Task<List<Todo>> GetTodoList();
    Task<Todo> AddTodo(AddTodoDto addTodoDto);
    int FindFactorial(int row);
}
