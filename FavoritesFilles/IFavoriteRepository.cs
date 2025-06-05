using System.Collections.Generic;
using System.Threading.Tasks;
using FullPetflix.Models;
using FullPetflix.FavoritesFiles;
using FullPetflix.FavoritesFiles;

namespace FullPetflix.FavoritesFiles
{
    public interface IFavoriteRepository
    {
        Task AddFavoriteAsync(Favorite favorite);
        Task RemoveFavoriteAsync(int userId, int itemId);
        Task<List<Favorite>> GetUserFavoritesAsync(int userId);
    }
}