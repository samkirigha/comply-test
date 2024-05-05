using Microsoft.EntityFrameworkCore;
using TodoApi.Data.EntityConfigs;
using TodoApi.Models;

namespace TodoApi.Data;

public class TodoDbContext : DbContext
{    
    public TodoDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Todo> Todos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new TodoConfig());
    }
}
