using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace FullPetflix.ProductReviewFiles // Ensure correct namespace
{
    [ApiController]
    [Route("api/[controller]")] // e.g., api/ProductReview
    public class PR_Controller : ControllerBase
    {
        private readonly IPR_Repository _prRepository;

        public PR_Controller(IPR_Repository prRepository)
        {
            _prRepository = prRepository;
        }

        // ... (All the CRUD actions - Get, GetAll, Create, Update, Delete)

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductReview>> GetProductReview(int id)
        {
            var review = await _prRepository.GetProductReviewByIdAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            return review;
        }

        [HttpGet("product/{productId}")] // New route
        public async Task<ActionResult<IEnumerable<ProductReview>>> GetProductReviewsByProductId(int productId)
        {
            try
            {
                var reviews = await _prRepository.GetProductReviewsByProductIdAsync(productId);
                return Ok(reviews);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductReview>>> GetAllProductReviews()
        {
            return await _prRepository.GetAllProductReviewsAsync();
        }

        [HttpPost]
        public async Task<ActionResult<ProductReview>> CreateProductReview(ProductReview review)
        {
            await _prRepository.AddProductReviewAsync(review);
            return CreatedAtAction(nameof(GetProductReview), new { id = review.ProductReviewId }, review);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductReview(int id, ProductReview review)
        {
            if (id != review.ProductReviewId)
            {
                return BadRequest();
            }

            await _prRepository.UpdateProductReviewAsync(review);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductReview(int id)
        {
            await _prRepository.DeleteProductReviewAsync(id);
            return NoContent();
        }

    }
}