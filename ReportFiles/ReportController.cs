using FullPetflix.Models;
using FullPetflix.ReportFiles;
using FullPetFlix.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullPetflix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportRepository _reportRepository;
        private readonly AppDbContext _context; // Add AppDbContext field

        public ReportController(IReportRepository reportRepository, AppDbContext context)
        {
            _reportRepository = reportRepository;
            _context = context; // Initialize context
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Report>>> GetAllReports()
        {
            try
            {
                var reports = await _reportRepository.GetAllReports();
                return Ok(reports);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Report>> GetReportById(int id)
        {
            try
            {
                var report = await _reportRepository.GetReportById(id);
                if (report == null)
                {
                    return NotFound();
                }
                return Ok(report);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<Report>>> GetReportsByUserId(int userId)
        {
            try
            {
                var reports = await _reportRepository.GetReportsByUserId(userId);
                return Ok(reports);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Report>> CreateReport([FromBody] ReportCreateDto reportDto)
        {
            try
            {
                // Validate input
                if (reportDto == null)
                {
                    return BadRequest("Report data is null.");
                }
                if (string.IsNullOrEmpty(reportDto.Content))
                {
                    return BadRequest("Content is required.");
                }
                if (!reportDto.TargetType.HasValue || !Enum.IsDefined(typeof(ReportTargetType), reportDto.TargetType.Value))
                {
                    return BadRequest("Invalid or missing TargetType.");
                }

                // Validate foreign keys based on TargetType
                bool isValidTarget = false;
                if (reportDto.TargetType == ReportTargetType.User)
                {
                    if (!reportDto.ReportedUserId.HasValue || reportDto.ReportedUserId <= 0)
                    {
                        return BadRequest("ReportedUserId must be a valid user ID for TargetType User.");
                    }
                    if (reportDto.ReportedAnimalId.HasValue || reportDto.ReportedProductId.HasValue)
                    {
                        return BadRequest("ReportedAnimalId and ReportedProductId must be null for TargetType User.");
                    }
                    isValidTarget = true;
                }
                else if (reportDto.TargetType == ReportTargetType.Animal)
                {
                    if (!reportDto.ReportedAnimalId.HasValue || reportDto.ReportedAnimalId <= 0)
                    {
                        return BadRequest("ReportedAnimalId must be a valid animal ID for TargetType Animal.");
                    }
                    if (reportDto.ReportedUserId.HasValue || reportDto.ReportedProductId.HasValue)
                    {
                        return BadRequest("ReportedUserId and ReportedProductId must be null for TargetType Animal.");
                    }
                    isValidTarget = true;
                }
                else if (reportDto.TargetType == ReportTargetType.Product)
                {
                    if (!reportDto.ReportedProductId.HasValue || reportDto.ReportedProductId <= 0)
                    {
                        return BadRequest("ReportedProductId must be a valid product ID for TargetType Product.");
                    }
                    if (reportDto.ReportedUserId.HasValue || reportDto.ReportedAnimalId.HasValue)
                    {
                        return BadRequest("ReportedUserId and ReportedAnimalId must be null for TargetType Product.");
                    }
                    isValidTarget = true;
                }

                if (!isValidTarget)
                {
                    return BadRequest("Invalid target configuration.");
                }

                // Validate ReporterId
                if (reportDto.ReporterId <= 0)
                {
                    return BadRequest("ReporterId must be a valid user ID.");
                }

                // Check if referenced entities exist
                var reporterExists = await _context.Users.AnyAsync(u => u.userId == reportDto.ReporterId);
                if (!reporterExists)
                {
                    return BadRequest("ReporterId does not exist.");
                }

                if (reportDto.ReportedUserId.HasValue)
                {
                    var userExists = await _context.Users.AnyAsync(u => u.userId == reportDto.ReportedUserId.Value);
                    if (!userExists)
                    {
                        return BadRequest("ReportedUserId does not exist.");
                    }
                }
                if (reportDto.ReportedAnimalId.HasValue)
                {
                    var animalExists = await _context.Animals.AnyAsync(a => a.animal_id == reportDto.ReportedAnimalId.Value);
                    if (!animalExists)
                    {
                        return BadRequest("ReportedAnimalId does not exist.");
                    }
                }
                if (reportDto.ReportedProductId.HasValue)
                {
                    var productExists = await _context.Products.AnyAsync(p => p.product_id == reportDto.ReportedProductId.Value);
                    if (!productExists)
                    {
                        return BadRequest("ReportedProductId does not exist.");
                    }
                }

                var report = new Report
                {
                    ReporterId = reportDto.ReporterId,
                    TargetType = reportDto.TargetType.Value,
                    ReportedUserId = reportDto.ReportedUserId,
                    ReportedAnimalId = reportDto.ReportedAnimalId,
                    ReportedProductId = reportDto.ReportedProductId,
                    Content = reportDto.Content
                };

                var createdReport = await _reportRepository.AddReport(report);
                return CreatedAtAction(nameof(GetReportById), new { id = createdReport.ReportId }, createdReport);
            }
            catch (DbUpdateException dbEx)
            {
                return StatusCode(500, $"Database error: {dbEx.InnerException?.Message ?? dbEx.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.InnerException?.Message ?? ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Report>> UpdateReport(int id, [FromBody] ReportUpdateDto reportDto)
        {
            try
            {
                if (reportDto == null)
                {
                    return BadRequest("Invalid report data.");
                }

                var report = await _reportRepository.GetReportById(id);
                if (report == null)
                {
                    return NotFound();
                }

                report.Status = reportDto.Status ?? report.Status;
                report.ResolutionNotes = reportDto.ResolutionNotes ?? report.ResolutionNotes;
                report.Content = reportDto.Content ?? report.Content;

                var updatedReport = await _reportRepository.UpdateReport(report);
                return Ok(updatedReport);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteReport(int id)
        {
            try
            {
                var report = await _reportRepository.GetReportById(id);
                if (report == null)
                {
                    return NotFound();
                }

                await _reportRepository.DeleteReport(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }

    // DTOs
    public class ReportCreateDto
    {
        public int ReporterId { get; set; }
        public ReportTargetType? TargetType { get; set; }
        public int? ReportedUserId { get; set; }
        public int? ReportedAnimalId { get; set; }
        public int? ReportedProductId { get; set; }
        public string Content { get; set; }
    }

    public class ReportUpdateDto
    {
        public ReportStatus? Status { get; set; }
        public string ResolutionNotes { get; set; }
        public string Content { get; set; }
    }
}