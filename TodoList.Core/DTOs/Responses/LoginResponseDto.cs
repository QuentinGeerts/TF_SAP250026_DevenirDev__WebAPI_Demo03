namespace TodoList.Core.DTOs.Responses;

public class LoginResponseDto
{
    public string Token { get; set; } = null!;
    public DateTime Expiration { get; set; }
}
