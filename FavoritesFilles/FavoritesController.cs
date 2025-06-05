using FullPetflix.FavoritesFiles;
using Microsoft.AspNetCore.Mvc;

namespace FullPetflix.FavoritesFiles
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoriteController : ControllerBase
    {
        private readonly IFavoriteRepository _favoriteRepository;

        public FavoriteController(IFavoriteRepository favoriteRepository)
        {
            _favoriteRepository = favoriteRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddFavorite([FromBody] Favorite favorite)
        {
            await _favoriteRepository.AddFavoriteAsync(favorite);
            return Ok(new { message = "Item added to favorites" });
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveFavorite(int userId, int itemId)
        {
            await _favoriteRepository.RemoveFavoriteAsync(userId, itemId);
            return Ok(new { message = "Item removed from favorites" });
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<List<Favorite>>> GetUserFavorites(int userId)
        {
            var favorites = await _favoriteRepository.GetUserFavoritesAsync(userId);
            return Ok(favorites);
        }
    }
}