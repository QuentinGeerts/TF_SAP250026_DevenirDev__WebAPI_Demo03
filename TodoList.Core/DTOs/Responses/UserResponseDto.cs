namespace TodoList.Core.DTOs.Responses;

public class UserResponseDto
{
    public Guid Id { get; set; }
    public string Email { get; set; } = null!;

    public string? Lastname { get; set; }
    public string? Firstname { get; set; }
}
