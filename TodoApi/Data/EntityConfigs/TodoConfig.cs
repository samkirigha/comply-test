using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoApi.Models;

namespace TodoApi.Data.EntityConfigs;

public class TodoConfig : IEntityTypeConfiguration<Todo>
{
    public void Configure(EntityTypeBuilder<Todo> builder)
    {
        builder.ToTable("Todos");
        builder.Property(p => p.Id).ValueGeneratedOnAdd();
        builder.Property(p => p.RowVersion).ValueGeneratedOnAddOrUpdate().IsRowVersion();
    }
}
