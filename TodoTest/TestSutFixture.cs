using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TodoApi.Data;
using TodoApi.Models;

namespace TodoTest;

public class TestSutFixture<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
{
    private const string DATABASE_CONNECTION_STRING = "Data Source=:memory:";

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.RemoveAll(typeof(TodoDbContext));
            services.AddDbContext<TodoDbContext>(options =>
            {
                options.UseSqlite(DATABASE_CONNECTION_STRING);
            });
            
            using (var dbContext = services
                .BuildServiceProvider()
                .GetRequiredService<TodoDbContext>())
                {
                    dbContext.Database.EnsureDeleted();
                    dbContext.Database.EnsureCreated();
                    dbContext.Todos.AddRange(Seeds.Todos);
                    dbContext.SaveChanges();
                }
        });
    }
}

public static class Seeds
{
    public static List<Todo> Todos = new List<Todo>
    {
        new Todo
        {
            Id = 1,
            Title = Faker.Lorem.Sentence(),
            Description = Faker.Lorem.Paragraph(),
        },
        new Todo
        {
            Id = 2,
            Title = Faker.Lorem.Sentence(),
            Description = Faker.Lorem.Paragraph(),
        },
        new Todo
        {
            Id = 3,
            Title = Faker.Lorem.Sentence(),
            Description = Faker.Lorem.Paragraph(),
        },
        new Todo
        {
            Id = 4,
            Title = Faker.Lorem.Sentence(),
            Description = Faker.Lorem.Paragraph(),
        }
    };
}
