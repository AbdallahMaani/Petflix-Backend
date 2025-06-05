using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FullPetflix.Models;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace FullPetflix.ProductFiles
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly AppDbContext _context;

        public ProductsController(IProductRepository productRepository, AppDbContext context)
        {
            _productRepository = productRepository;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            try
            {
                var products = await _productRepository.GetAllProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult<Product>> GetProductById(int productId)
        {
            try
            {
                var product = await _productRepository.GetProductById(productId);
                if (product == null) return NotFound();
                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct([FromBody] Product product)
        {
            try
            {
                if (product == null || product.userId == 0)
                    return BadRequest("Product data or User ID is missing");

                // Verify user exists
                var userExists = await _context.Users.AnyAsync(u => u.userId == product.userId);
                if (!userExists)
                    return BadRequest("Invalid User ID - User does not exist");

                var addedProduct = await _productRepository.AddProduct(product);
                return CreatedAtAction(nameof(GetProductById),
                    new { productId = addedProduct.product_id }, addedProduct);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{productId}")]
        public async Task<IActionResult> UpdateProduct(int productId, [FromBody] Product product)
        {
            try
            {
                if (productId != product.product_id)
                    return BadRequest();

                // Allow null or empty string for product_pic
                if (product.product_pic == string.Empty)
                    product.product_pic = null;

                var updatedProduct = await _productRepository.UpdateProduct(product);
                if (updatedProduct == null) return NotFound();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            try
            {
                var product = await _productRepository.GetProductById(productId);
                if (product == null)
                {
                    return NotFound($"Product with ID {productId} not found");
                }

                var success = await _productRepository.DeleteProduct(productId);
                if (!success)
                {
                    return StatusCode(500, "Failed to delete product");
                }

                return NoContent();
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, $"Database error while deleting product: {ex.InnerException?.Message ?? ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error while deleting product: {ex.Message}");
            }
        }

        [HttpPatch("{productId}/remove-pic")]
        public async Task<IActionResult> RemoveProductPicture(int productId)
        {
            try
            {
                var product = await _productRepository.GetProductById(productId);
                if (product == null) return NotFound();

                product.product_pic = null;
                await _productRepository.UpdateProduct(product);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}