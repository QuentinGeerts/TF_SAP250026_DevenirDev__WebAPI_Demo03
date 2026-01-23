using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace TodoList.API.DTOs.Requests;

public class RegisterRequestDto
{
    [Required(ErrorMessage = "L'email est requis.")]
    [EmailAddress(ErrorMessage = "Le format est incorrect.")]
    public string Email { get; set; } = null!;

    [RegexStringValidator("^(?=.*[A-Z])(?=.*[a-z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$")]
    public string Password { get; set; } = null!;


    [StringLength(100, ErrorMessage = "La longueur maximum doit être comprise entre 2 et 100 caractères", MinimumLength = 2)]
    public string? Lastname { get; set; }

    [StringLength(100, ErrorMessage = "La longueur maximum doit être comprise entre 2 et 100 caractères", MinimumLength = 2)]
    public string? Firstname { get; set; }
}
