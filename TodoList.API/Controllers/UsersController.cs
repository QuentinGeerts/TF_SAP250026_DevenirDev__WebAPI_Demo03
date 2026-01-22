using Microsoft.AspNetCore.Mvc;
using TodoList.Core.Interfaces.Services;
using TodoList.Domain.Entities;

// TODO:
// - Implémenter les méthodes PUT et POST
// - Changer les types de retour des méthodes GET, PUT et POST pour utiliser des DTOs au lieu des entités directement (utilisation de Mappers)
// - Implémenter le Hashing des mots de passe lors de la création et de la mise à jour des utilisateurs
// - Implémenter le système d'authentification et d'autorisation (JWT)

namespace TodoList.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/Users
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<User>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        // GET: api/Users/5
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<User>> GetUser([FromRoute] Guid id)
        {
            var existingUser = await _userService.GetByIdAsync(id);
            if (existingUser == null)
                return NotFound();

            return Ok(existingUser);

        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(Guid id, User user)
        {
            // TODO
            return Ok();

        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            // TODO
            return Ok();
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
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
            catch (Exception)
            {
                return BadRequest();
            }

        }
    }
}
