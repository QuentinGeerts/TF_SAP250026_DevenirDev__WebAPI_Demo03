using System.ComponentModel.DataAnnotations;

namespace TodoList.Core.DTOs.Requests;

public class RegisterRequestDto
{
    [Required(ErrorMessage = "L'email est requis.")]
    [EmailAddress(ErrorMessage = "Le format est incorrect.")]
    public string Email { get; set; } = null!;

    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?=&])[A-Za-z\d@$!%*?=&]{8,}$",
        ErrorMessage = "Le mot de passe doit contenir au moins 8 caractères, une majuscule, une minuscule, un chiffre et un caractère spécial")]
    public string Password { get; set; } = null!;


    [StringLength(100, ErrorMessage = "La longueur maximum doit être comprise entre 2 et 100 caractères", MinimumLength = 2)]
    public string? Lastname { get; set; }

    [StringLength(100, ErrorMessage = "La longueur maximum doit être comprise entre 2 et 100 caractères", MinimumLength = 2)]
    public string? Firstname { get; set; }
}
