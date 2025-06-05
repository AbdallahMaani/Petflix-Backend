using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FullPetflix.Models; // Your DbContext
using FullPetflix.AnimalReviewFiles;
using System.Linq;
using System;

namespace FullPetflix.AnimalReviewFiles
{
    public class AR_Repository : IAR_Repository
    {
        private readonly AppDbContext _context;

        public AR_Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<AnimalReview> GetAnimalReviewByIdAsync(int id)
        {
            return await _context.AnimalReviews.FindAsync(id);
        }

        public async Task<List<AnimalReview>> GetAllAnimalReviewsAsync()
        {
            return await _context.AnimalReviews.ToListAsync();
        }

        public async Task<List<AnimalReview>> GetAnimalReviewsByAnimalIdAsync(int animalId)
        {
            return await _context.AnimalReviews
                .Where(ar => ar.AnimalId == animalId)
                .Include(ar => ar.Reviewer)
                .ToListAsync();
        }

        public async Task AddAnimalReviewAsync(AnimalReview review)
        {
            _context.AnimalReviews.Add(review);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAnimalReviewAsync(AnimalReview review)
        {
            _context.AnimalReviews.Update(review);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAnimalReviewAsync(int id)
        {
            var review = await _context.AnimalReviews.FindAsync(id);
            if (review != null)
            {
                _context.AnimalReviews.Remove(review);
                await _context.SaveChangesAsync();
            }
        }
    }
}