using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FullPetflix.Models;
using FullPetflix.FeedbackFiles;
using FullPetflix.Models;

namespace FullPetflix.FeedbackFiles
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly AppDbContext _context;

        public FeedbackRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Feedback> AddFeedbackAsync(Feedback feedback)
        {
            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();
            return feedback;
        }

        public async Task<IEnumerable<Feedback>> GetAllFeedbackAsync()
        {
            return await _context.Feedbacks
                .Include(f => f.User)
                .OrderByDescending(f => f.SubmissionDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Feedback>> GetFeedbackByUserIdAsync(int userId)
        {
            return await _context.Feedbacks
                .Where(f => f.UserId == userId)
                .Include(f => f.User)
                .OrderByDescending(f => f.SubmissionDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Feedback>> GetFeedbackByTypeAsync(string feedbackType)
        {
            return await _context.Feedbacks
                .Where(f => f.FeedbackType == feedbackType)
                .Include(f => f.User)
                .OrderByDescending(f => f.SubmissionDate)
                .ToListAsync();
        }

        public async Task<Feedback> UpdateFeedbackStatusAsync(int feedbackId, string status, string response = null)
        {
            var feedback = await _context.Feedbacks.FindAsync(feedbackId);
            if (feedback == null)
                return null;

            feedback.Status = status;
            if (response != null)
            {
                feedback.Response = response;
            }

            await _context.SaveChangesAsync();
            return feedback;
        }

        public async Task<Feedback> GetFeedbackByIdAsync(int feedbackId)
        {
            return await _context.Feedbacks
                .Include(f => f.User)
                .FirstOrDefaultAsync(f => f.FeedbackId == feedbackId);
        }

        public async Task<bool> DeleteFeedbackAsync(int feedbackId)
        {
            var feedback = await _context.Feedbacks.FindAsync(feedbackId);
            if (feedback == null)
                return false;

            _context.Feedbacks.Remove(feedback);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Feedback> UpdateFeedbackAsync(int feedbackId, Feedback feedbackUpdate)
        {
            var feedback = await _context.Feedbacks.FindAsync(feedbackId);
            if (feedback == null)
                return null;

            // Update only the fields we want to allow editing
            feedback.FeedbackType = feedbackUpdate.FeedbackType;
            feedback.Content = feedbackUpdate.Content;
            // Preserve other fields like UserId, SubmissionDate, Status, Response

            await _context.SaveChangesAsync();
            return feedback;
        }
    }
}