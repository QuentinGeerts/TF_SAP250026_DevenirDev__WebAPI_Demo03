using System.ComponentModel.DataAnnotations;

namespace TodoList.Core.DTOs.Requests;

public class AddTodoRequestDto
{
    [Required(ErrorMessage = "Le titre est requis.")]
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
}
