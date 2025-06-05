using FullPetflix.UserFiles;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullPetflix.UserFiles
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository usersRepository)
        {
            _userRepository = usersRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
            try
            {
                return Ok(await _userRepository.GetUsers());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUser(int id)
        {
            try
            {
                var user = await _userRepository.GetUser(id);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Users>>> Search(string name, Gender? gender)
        {
            try
            {
                var users = await _userRepository.Search(name, gender);
                if (users.Any())
                {
                    return Ok(users);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Users>> CreateUser(Users user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest();
                }

                var existingUserByUsername = await _userRepository.GetUserByUsername(user.username);
                if (existingUserByUsername != null)
                {
                    return Conflict("Username is already in use.");
                }

                var existingUserByEmail = await _userRepository.GetUserByEmail(user.email);
                if (existingUserByEmail != null)
                {
                    return Conflict("Email is already in use.");
                }

                var createdUser = await _userRepository.AddUser(user);
                return CreatedAtAction(nameof(GetUser), new { id = createdUser.userId }, createdUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Users>> UpdateUser(int id, Users user)
        {
            try
            {
                if (id != user.userId)
                {
                    return BadRequest();
                }

                var existingUser = await _userRepository.GetUser(id);
                if (existingUser == null)
                {
                    return NotFound();
                }

                var updatedUser = await _userRepository.UpdateUser(user);
                return Ok(updatedUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}/password")]
        public async Task<ActionResult<Users>> UpdateUserPassword(int id, [FromBody] PasswordUpdateDto passwordUpdate)
        {
            try
            {
                if (passwordUpdate == null || string.IsNullOrEmpty(passwordUpdate.OldPassword) || string.IsNullOrEmpty(passwordUpdate.NewPassword))
                {
                    return BadRequest("Old and new passwords are required.");
                }

                var updatedUser = await _userRepository.UpdateUserPassword(id, passwordUpdate.OldPassword, passwordUpdate.NewPassword);
                if (updatedUser == null)
                {
                    return NotFound("User not found.");
                }

                return Ok(updatedUser);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            try
            {
                var existingUser = await _userRepository.GetUser(id);
                if (existingUser == null)
                {
                    return NotFound();
                }

                await _userRepository.DeleteUser(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }

    // DTO for password update
    public class PasswordUpdateDto
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}