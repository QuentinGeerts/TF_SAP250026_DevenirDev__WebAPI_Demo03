using TodoList.Domain.Enums;

namespace TodoList.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;

    public UserRole Role { get; set; }

    public string? Lastname { get; set; }
    public string? Firstname { get; set; }

    public ICollection<Todo> Todos { get; set; } = [];

}
