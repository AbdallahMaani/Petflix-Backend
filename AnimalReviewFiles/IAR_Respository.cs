using System.Collections.Generic;
using System.Threading.Tasks;
using FullPetflix.AnimalReviewFiles;

namespace FullPetflix.AnimalReviewFiles
{
    public interface IAR_Repository
    {
        Task<AnimalReview> GetAnimalReviewByIdAsync(int id);
        Task<List<AnimalReview>> GetAllAnimalReviewsAsync();
        Task<List<AnimalReview>> GetAnimalReviewsByAnimalIdAsync(int animalId);
        Task AddAnimalReviewAsync(AnimalReview review);
        Task UpdateAnimalReviewAsync(AnimalReview review);
        Task DeleteAnimalReviewAsync(int id);
    }
}
