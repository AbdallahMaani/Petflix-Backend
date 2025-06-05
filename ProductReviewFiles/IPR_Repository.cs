using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullPetflix.ProductReviewFiles  // Consistent namespace
{
    public interface IPR_Repository
    {
        Task<ProductReview> GetProductReviewByIdAsync(int id);
        Task<List<ProductReview>> GetAllProductReviewsAsync();
        Task<List<ProductReview>> GetProductReviewsByProductIdAsync(int productId); // New method
        Task AddProductReviewAsync(ProductReview review);
        Task UpdateProductReviewAsync(ProductReview review);
        Task DeleteProductReviewAsync(int id);
        // Add other methods as needed (e.g., filtering, pagination)
    }
}
