using FullPetflix.FeedbackFiles;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullPetflix.FeedbackFiles
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbackController(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Feedback>> SubmitFeedback([FromBody] Feedback feedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdFeedback = await _feedbackRepository.AddFeedbackAsync(feedback);
            return CreatedAtAction(nameof(GetFeedbackById), new { id = createdFeedback.FeedbackId }, createdFeedback);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Feedback>>> GetAllFeedback()
        {
            var feedbacks = await _feedbackRepository.GetAllFeedbackAsync();
            return Ok(feedbacks);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<Feedback>>> GetFeedbackByUser(int userId)
        {
            var feedbacks = await _feedbackRepository.GetFeedbackByUserIdAsync(userId);
            return Ok(feedbacks);
        }

        [HttpGet("type/{feedbackType}")]
        public async Task<ActionResult<IEnumerable<Feedback>>> GetFeedbackByType(string feedbackType)
        {
            var feedbacks = await _feedbackRepository.GetFeedbackByTypeAsync(feedbackType);
            return Ok(feedbacks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Feedback>> GetFeedbackById(int id)
        {
            var feedback = await _feedbackRepository.GetFeedbackByIdAsync(id);
            if (feedback == null)
            {
                return NotFound();
            }
            return Ok(feedback);
        }

        [HttpPatch("{id}/status")]
        public async Task<ActionResult<Feedback>> UpdateFeedbackStatus(int id, [FromBody] FeedbackStatusUpdateDto statusUpdate)
        {
            var feedback = await _feedbackRepository.UpdateFeedbackStatusAsync(
                id,
                statusUpdate.Status,
                statusUpdate.Response);

            if (feedback == null)
            {
                return NotFound();
            }

            return Ok(feedback);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Feedback>> UpdateFeedback(int id, [FromBody] Feedback feedbackUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedFeedback = await _feedbackRepository.UpdateFeedbackAsync(id, feedbackUpdate);
            if (updatedFeedback == null)
            {
                return NotFound();
            }

            return Ok(updatedFeedback);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedback(int id)
        {
            var success = await _feedbackRepository.DeleteFeedbackAsync(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent(); // 204 No Content on successful deletion
        }
    }

    public class FeedbackStatusUpdateDto
    {
        public string Status { get; set; }
        public string? Response { get; set; }
    }
}