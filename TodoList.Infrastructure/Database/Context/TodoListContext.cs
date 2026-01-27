using Microsoft.EntityFrameworkCore;
using TodoList.Domain.Entities;

namespace TodoList.Infrastructure.Database.Context;

public class TodoListContext : DbContext
{
    public TodoListContext(DbContextOptions options) : base(options) { }

    public DbSet<Todo> Todos { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TodoListContext).Assembly);
    }
}
