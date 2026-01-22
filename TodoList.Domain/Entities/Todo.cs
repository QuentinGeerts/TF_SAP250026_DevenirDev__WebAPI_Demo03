using TodoList.Domain.Enums;

namespace TodoList.Domain.Entities;

public class Todo
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public TodoStatus Status { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public DateTime CreatedAt { get; set; }
    public bool IsDeleted { get; set; }
}
