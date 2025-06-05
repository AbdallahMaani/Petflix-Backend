using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FullPetflix.AnimalReviewFiles;
using System;

namespace FullPetflix.AnimalReviewFiles
{
    [ApiController]
    [Route("api/[controller]")] // e.g., api/AnimalReview
    public class AR_Controller : ControllerBase
    {
        private readonly IAR_Repository _arRepository;

        public AR_Controller(IAR_Repository arRepository)
        {
            _arRepository = arRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AnimalReview>> GetAnimalReview(int id)
        {
            try
            {
                var review = await _arRepository.GetAnimalReviewByIdAsync(id);
                if (review == null)
                {
                    return NotFound();
                }
                return Ok(review);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnimalReview>>> GetAllAnimalReviews()
        {
            try
            {
                var reviews = await _arRepository.GetAllAnimalReviewsAsync();
                return Ok(reviews);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<AnimalReview>> CreateAnimalReview(AnimalReview review)
        {
            try
            {
                await _arRepository.AddAnimalReviewAsync(review);
                return CreatedAtAction(nameof(GetAnimalReview), new { id = review.AnimalReviewId }, review);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("animal/{animalId}")] // New route
        public async Task<ActionResult<IEnumerable<AnimalReview>>> GetAnimalReviewsByAnimalId(int animalId)
        {
            try
            {
                var reviews = await _arRepository.GetAnimalReviewsByAnimalIdAsync(animalId);
                return Ok(reviews);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAnimalReview(int id, AnimalReview review)
        {
            try
            {
                if (id != review.AnimalReviewId)
                {
                    return BadRequest();
                }

                await _arRepository.UpdateAnimalReviewAsync(review);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimalReview(int id)
        {
            try
            {
                await _arRepository.DeleteAnimalReviewAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}