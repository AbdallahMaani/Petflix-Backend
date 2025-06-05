using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using FullPetflix.Models;
using FullPetFlix.Repositories;

namespace FullPetFlix.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartsController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;

        public CartsController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<Cart>> GetCartByUserId(int userId)
        {
            var cart = await _cartRepository.GetCartByUserId(userId);
            if (cart == null)
            {
                return NotFound();
            }
            return Ok(cart);
        }

        [HttpPost("{userId}/items")]
        public async Task<ActionResult<Cart>> AddItemToCart(int userId, [FromBody] AddCartItemRequest request)
        {
            var cart = await _cartRepository.AddItemToCart(userId, request.ItemId, request.ItemType, request.Quantity);
            return Ok(cart);
        }

        [HttpDelete("{userId}/items/{cartItemId}")]
        public async Task<ActionResult<Cart>> RemoveItemFromCart(int userId, int cartItemId)
        {
            var cart = await _cartRepository.RemoveItemFromCart(userId, cartItemId);
            if (cart == null)
            {
                return NotFound();
            }
            return Ok(cart);
        }

        [HttpPut("{userId}/items/{cartItemId}")]
        public async Task<ActionResult<Cart>> UpdateItemQuantity(int userId, int cartItemId, [FromBody] UpdateQuantityRequest request)
        {
            var cart = await _cartRepository.UpdateItemQuantity(userId, cartItemId, request.Quantity);
            if (cart == null)
            {
                return NotFound();
            }
            return Ok(cart);
        }

        [HttpDelete("{userId}/clear")]
        public async Task<IActionResult> ClearCart(int userId)
        {
            await _cartRepository.ClearCart(userId);
            return NoContent();
        }
    }

    // Request DTOs
    public class AddCartItemRequest
    {
        public int ItemId { get; set; }
        public string ItemType { get; set; }
        public int Quantity { get; set; }
    }

    public class UpdateQuantityRequest
    {
        public int Quantity { get; set; }
    }
}