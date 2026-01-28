using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoList.API.Mappers;
using TodoList.Core.DTOs.Requests;
using TodoList.Core.DTOs.Responses;
using TodoList.Core.Interfaces.Services;

// TODO:
// - Implémenter les méthodes PUT et POST
// - Changer les types de retour des méthodes GET, PUT et POST pour utiliser des DTOs au lieu des entités directement (utilisation de Mappers)
// - Implémenter le Hashing des mots de passe lors de la création et de la mise à jour des utilisateurs
// - Implémenter le système d'authentification et d'autorisation (JWT)

namespace TodoList.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UsersController(IUserService _userService) : ControllerBase
    {
        // GET: api/Users
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UserResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<UserResponseDto>>> GetUsers()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users.ToUserResponseDtos());
        }

        // GET: api/Users/5
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(UserResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UserResponseDto>> GetUser([FromRoute] Guid id)
        {
            var existingUser = await _userService.GetByIdAsync(id);
            if (existingUser == null)
                return NotFound();

            //return Ok(UserMapperExtensions.ToUserResponseDto(existingUser));
            return Ok(existingUser.ToUserResponseDto());
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutUser([FromRoute] Guid id, [FromBody] UpdateUserRequestDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userService.GetByIdAsync(id);
            if (user == null)
                return NotFound(new { Message = "Utilisateur introuvable." });

            user.Email = request.Email;
            user.Lastname = request.Lastname;
            user.Firstname = request.Firstname;

            await _userService.UpdateAsync(id, user);

            return NoContent();

        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            try
            {
                await _userService.DeleteAsync(id);
                return Ok();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Error = ex.Message });
            }
        }
    }
}
