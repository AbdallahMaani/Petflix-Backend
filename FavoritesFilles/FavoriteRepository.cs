using Microsoft.EntityFrameworkCore; // Ensure this is present
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FullPetflix.Models;
using FullPetflix.FavoritesFiles;
using FullPetflix.FavoritesFiles;
using FullPetflix.Models;

namespace FullPetflix.FavoritesFiles
{
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly AppDbContext _context;

        public FavoriteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddFavoriteAsync(Favorite favorite)
        {
            if (favorite.AnimalId.HasValue && favorite.ProductId.HasValue)
            {
                throw new ArgumentException("A favorite can only reference an Animal or a Product, not both.");
            }

            if (!favorite.AnimalId.HasValue && !favorite.ProductId.HasValue)
            {
                throw new ArgumentException("A favorite must reference either an Animal or a Product.");
            }

            favorite.ItemId = favorite.AnimalId ?? favorite.ProductId;

            _context.Favorites.Add(favorite);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveFavoriteAsync(int userId, int itemId)
        {
            var favorite = await _context.Favorites
                .FirstOrDefaultAsync(f => f.UserId == userId && f.ItemId == itemId);

            if (favorite != null)
            {
                _context.Favorites.Remove(favorite);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Favorite>> GetUserFavoritesAsync(int userId)
        {
            return await _context.Favorites
                .Include(f => f.Animal)  // Eager load Animal data
                .Include(f => f.Product) // Eager load Product data
                .Where(f => f.UserId == userId)
                .ToListAsync();
        }
    }
}