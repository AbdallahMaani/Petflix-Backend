using System.Collections.Generic;
using System.Threading.Tasks;
using FullPetflix.Models;
using FullPetflix.ProductReviewFiles;
using Microsoft.EntityFrameworkCore;


namespace FullPetflix.ProductReviewFiles // Consistent namespace
{
    public class PR_Repository : IPR_Repository
    {
        private readonly AppDbContext _context;

        public PR_Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ProductReview> GetProductReviewByIdAsync(int id)
        {
            return await _context.ProductReviews.FindAsync(id); // Use FindAsync
        }

        public async Task<List<ProductReview>> GetAllProductReviewsAsync()
        {
            return await _context.ProductReviews.ToListAsync();
        }

        public async Task<List<ProductReview>> GetProductReviewsByProductIdAsync(int productId)
        {
            return await _context.ProductReviews
                .Where(pr => pr.ProductId == productId)
                .ToListAsync();
        }

        public async Task AddProductReviewAsync(ProductReview review)
        {
            _context.ProductReviews.Add(review);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProductReviewAsync(ProductReview review)
        {
            _context.ProductReviews.Update(review);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductReviewAsync(int id)
        {
            var review = await _context.ProductReviews.FindAsync(id);
            if (review != null)
            {
                _context.ProductReviews.Remove(review);
                await _context.SaveChangesAsync();
            }
        }
    }
}