using System.Collections.Generic;
using System.Threading.Tasks;
using FullPetflix.Models;
using FullPetFlix.Repositories;


namespace FullPetFlix.Repositories
{
    public interface ICartRepository
    {
        Task<Cart> GetCartByUserId(int userId);
        Task<Cart> AddItemToCart(int userId, int itemId, string itemType, int quantity);
        Task<Cart> RemoveItemFromCart(int userId, int cartItemId);
        Task<Cart> UpdateItemQuantity(int userId, int cartItemId, int quantity);
        Task ClearCart(int userId);
    }
}