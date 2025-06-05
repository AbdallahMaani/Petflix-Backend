using System.Collections.Generic;
using System.Threading.Tasks;
using FullPetflix.FeedbackFiles;

namespace FullPetflix.FeedbackFiles
{
    public interface IFeedbackRepository
    {
        Task<Feedback> AddFeedbackAsync(Feedback feedback);
        Task<IEnumerable<Feedback>> GetAllFeedbackAsync();
        Task<IEnumerable<Feedback>> GetFeedbackByUserIdAsync(int userId);
        Task<IEnumerable<Feedback>> GetFeedbackByTypeAsync(string feedbackType);
        Task<Feedback> UpdateFeedbackStatusAsync(int feedbackId, string status, string response = null);
        Task<Feedback> GetFeedbackByIdAsync(int feedbackId);
        Task<bool> DeleteFeedbackAsync(int feedbackId);
        Task<Feedback> UpdateFeedbackAsync(int feedbackId, Feedback feedbackUpdate); // New method
    }
}