using FullPetflix.Models;
using FullPetflix.ReportFiles;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullPetFlix.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly AppDbContext _context;

        public ReportRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Report>> GetAllReports()
        {
            return await _context.Reports
                .Include(r => r.Reporter)
                .Include(r => r.ReportedUser)
                .Include(r => r.ReportedAnimal)
                .Include(r => r.ReportedProduct)
                .ToListAsync();
        }

        public async Task<Report> GetReportById(int reportId)
        {
            return await _context.Reports
                .Include(r => r.Reporter)
                .Include(r => r.ReportedUser)
                .Include(r => r.ReportedAnimal)
                .Include(r => r.ReportedProduct)
                .FirstOrDefaultAsync(r => r.ReportId == reportId);
        }

        public async Task<IEnumerable<Report>> GetReportsByUserId(int userId)
        {
            return await _context.Reports
                .Include(r => r.Reporter)
                .Include(r => r.ReportedUser)
                .Include(r => r.ReportedAnimal)
                .Include(r => r.ReportedProduct)
                .Where(r => r.ReporterId == userId)
                .ToListAsync();
        }

        public async Task<Report> AddReport(Report report)
        {
            report.CreatedAt = DateTime.UtcNow;
            report.Status = ReportStatus.Pending;
            var result = await _context.Reports.AddAsync(report);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Report> UpdateReport(Report report)
        {
            var existingReport = await _context.Reports.FirstOrDefaultAsync(r => r.ReportId == report.ReportId);
            if (existingReport == null)
            {
                return null;
            }

            existingReport.Status = report.Status ?? existingReport.Status;
            existingReport.ResolutionNotes = report.ResolutionNotes ?? existingReport.ResolutionNotes;
            existingReport.Content = report.Content ?? existingReport.Content;
            if (report.Status == ReportStatus.Resolved || report.Status == ReportStatus.Rejected)
            {
                existingReport.ResolvedAt = DateTime.UtcNow;
            }

            await _context.SaveChangesAsync();
            return existingReport;
        }

        public async Task DeleteReport(int reportId)
        {
            var report = await _context.Reports.FirstOrDefaultAsync(r => r.ReportId == reportId);
            if (report != null)
            {
                _context.Reports.Remove(report);
                await _context.SaveChangesAsync();
            }
        }
    }
}