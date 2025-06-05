using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FullPetflix.UserFiles;
using Microsoft.EntityFrameworkCore;
using FullPetflix.Models;
using FullPetflix.AnimalFiles;
using System.Reflection;

namespace FullPetflix.AnimalFiles
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly AppDbContext _context; // Add DbContext

        // Update constructor to inject both
        public AnimalsController(IAnimalRepository animalRepository, AppDbContext context)
        {
            _animalRepository = animalRepository;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Animal>>> GetAnimals()
        {
            try
            {
                var animals = await _animalRepository.GetAnimals();
                return Ok(animals);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Animal>> GetAnimal(int id)
        {
            try
            {
                var animal = await _animalRepository.GetAnimal(id);
                if (animal == null)
                {
                    return NotFound();
                }
                return Ok(animal);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<Animal>>> GetAnimalsByUserId(int userId)
        {
            try
            {
                var animals = await _animalRepository.GetAnimalsByUserId(userId);
                return Ok(animals);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Animal>> CreateAnimal([FromBody] Animal animal)
        {
            try
            {
                if (animal == null || animal.userId == 0)
                {
                    return BadRequest("Animal data or User ID is missing");
                }

                // Verify user exists using injected context
                var userExists = await _context.Users.AnyAsync(u => u.userId == animal.userId);
                if (!userExists)
                {
                    return BadRequest("Invalid User ID - User does not exist");
                }

                var createdAnimal = await _animalRepository.AddAnimal(animal);
                return CreatedAtAction(nameof(GetAnimal), new { id = createdAnimal.animal_id }, createdAnimal);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAnimal(int id, [FromBody] Animal animal)
        {
            try
            {
                if (id != animal.animal_id)
                {
                    return BadRequest();
                }

                // Allow null or empty string for animal_pic
                if (animal.animal_pic == string.Empty)
                {
                    animal.animal_pic = null;
                }

                var updatedAnimal = await _animalRepository.UpdateAnimal(animal);
                if (updatedAnimal == null)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimal(int id)
        {
            try
            {
                var animal = await _animalRepository.GetAnimal(id);
                if (animal == null)
                {
                    return NotFound($"Animal with ID {id} not found");
                }

                await _animalRepository.DeleteAnimal(id);
                return NoContent();
            }
            catch (DbUpdateException ex)
            {
                // Specific handling for database-related errors
                return StatusCode(500, $"Database error while deleting animal: {ex.InnerException?.Message ?? ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error while deleting animal: {ex.Message}");
            }
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Animal>>> SearchAnimals(
            string category = null,
            string type = null,
            Gender? gender = null)
        {
            try
            {
                var animals = await _animalRepository.Search(category, type, gender);
                if (animals == null || !animals.Any())
                {
                    return NotFound();
                }
                return Ok(animals);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}