using TodoList.Core.DTOs.Requests;
using TodoList.Domain.Entities;
using TodoList.Domain.Enums;

namespace TodoList.Core.Mappers;

public static class TodoMapperExtensions
{

    public static Todo ToTodo (this AddTodoRequestDto request, Guid userId)
    {
        return new Todo
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description,
            Status = TodoStatus.NotStarted,
            CreatedAt = DateTime.UtcNow,
            UserId = userId,
            IsDeleted = false
        };
    }

}
