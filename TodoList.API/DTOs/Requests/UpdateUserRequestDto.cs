using System.ComponentModel.DataAnnotations;

namespace TodoList.API.DTOs.Requests;

public class UpdateUserRequestDto
{
    [Required(ErrorMessage = "L'email est requis.")]
    [EmailAddress(ErrorMessage = "Le format de l'email est invalide.")]
    public string Email { get; set; } = null!;

    [StringLength(100, ErrorMessage = "La longueur maximum doit être comprise entre 2 et 100 caractères", MinimumLength = 2)]
    public string Lastname { get; set; } = null!;

    [StringLength(100, ErrorMessage = "La longueur maximum doit être comprise entre 2 et 100 caractères", MinimumLength = 2)]
    public string Firstname { get; set; } = null!;
}
