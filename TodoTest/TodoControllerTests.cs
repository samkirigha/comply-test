using System.Net.Http.Json;
using System.Text.Json;
using TodoApi.Dtos;
using TodoApi.Models;

namespace TodoTest;

public class TodoControllerTests : IClassFixture<TestSutFixture<Program>>
{
    private readonly TestSutFixture<Program> _fixture;

    public TodoControllerTests(TestSutFixture<Program> fixture)
        => _fixture = fixture;

    [Fact]
    public async Task Can_Get_TodoList()
    {
        var todos = Seeds.Todos.Select(todo => todo.Id).ToList();
        var client = _fixture.CreateClient();
        var response = await client.GetAsync("/api/Todo");

        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var body = JsonSerializer.Deserialize<List<TodoDetailsDto>>(content);

        Assert.NotNull(body);
        Assert.All(body, it => todos.Contains(it.Id));
    }
    
    [Fact]
    public async Task Can_Add_Todo()
    {
        var todo = new AddTodoDto
        {
            Title = Faker.Lorem.Sentence(),
            Description = Faker.Lorem.Paragraph()
        };
        var client = _fixture.CreateClient();
        var response = await client.PostAsJsonAsync("/api/Todo", todo);

        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();

        Assert.Contains(todo.Title, content);
        Assert.Contains(todo.Description, content);
    }
    
    [Fact]
    public async Task Can_Find_Factorial()
    {
        var client = _fixture.CreateClient();
        var response = await client.GetAsync("/api/Todo/Factorial");

        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var body = JsonSerializer.Deserialize<List<TodoDetailsDto>>(content);

        Assert.NotNull(body);
        Assert.All(body, it => it.Factorial.HasValue.Equals(true));
    }
}