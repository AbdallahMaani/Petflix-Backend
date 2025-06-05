using System.Linq;
using System.Threading.Tasks;
using FullPetflix.Models;
using FullPetFlix.Repositories;
using Microsoft.EntityFrameworkCore;
using FullPetflix.Models;

namespace FullPetFlix.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly AppDbContext _context;

        public CartRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Cart> GetCartByUserId(int userId)
        {
            return await _context.Carts
                .Include(c => c.CartItems)
                .FirstOrDefaultAsync(c => c.UserId == userId);
        }

        public async Task<Cart> AddItemToCart(int userId, int itemId, string itemType, int quantity)
        {
            // Validate itemType
            if (itemType != "Animal" && itemType != "Product")
            {
                throw new ArgumentException("Invalid item type. Must be 'Animal' or 'Product'.");
            }

            // Check if the item exists
            bool itemExists = false;
            if (itemType == "Animal")
            {
                itemExists = await _context.Animals.AnyAsync(a => a.animal_id == itemId);
            }
            else if (itemType == "Product")
            {
                itemExists = await _context.Products.AnyAsync(p => p.product_id == itemId);
            }

            if (!itemExists)
            {
                throw new ArgumentException($"Item with ID {itemId} of type {itemType} does not exist.");
            }

            var cart = await GetCartByUserId(userId);
            if (cart == null)
            {
                cart = new Cart { UserId = userId };
                _context.Carts.Add(cart);
                await _context.SaveChangesAsync();
            }

            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ItemId == itemId && ci.ItemType == itemType);
            if (cartItem == null)
            {
                cartItem = new CartItem
                {
                    CartId = cart.CartId,
                    ItemId = itemId,
                    ItemType = itemType,
                    Quantity = quantity
                };
                cart.CartItems.Add(cartItem);
            }
            else
            {
                cartItem.Quantity += quantity;
            }

            await _context.SaveChangesAsync();
            return cart;
        }

        public async Task<Cart> RemoveItemFromCart(int userId, int cartItemId)
        {
            var cart = await GetCartByUserId(userId);
            if (cart == null) return null;

            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.CartItemId == cartItemId);
            if (cartItem != null)
            {
                cart.CartItems.Remove(cartItem);
                await _context.SaveChangesAsync();
            }

            return cart;
        }

        public async Task<Cart> UpdateItemQuantity(int userId, int cartItemId, int quantity)
        {
            var cart = await GetCartByUserId(userId);
            if (cart == null) return null;

            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.CartItemId == cartItemId);
            if (cartItem != null)
            {
                cartItem.Quantity = quantity;
                await _context.SaveChangesAsync();
            }

            return cart;
        }

        public async Task ClearCart(int userId)
        {
            var cart = await GetCartByUserId(userId);
            if (cart != null)
            {
                _context.CartItems.RemoveRange(cart.CartItems);
                await _context.SaveChangesAsync();
            }
        }
    }
}