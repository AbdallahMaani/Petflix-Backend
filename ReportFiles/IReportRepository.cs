using FullPetflix.ReportFiles;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullPetFlix.Repositories
{
    public interface IReportRepository
    {
        Task<IEnumerable<Report>> GetAllReports();
        Task<Report> GetReportById(int reportId);
        Task<IEnumerable<Report>> GetReportsByUserId(int userId);
        Task<Report> AddReport(Report report);
        Task<Report> UpdateReport(Report report);
        Task DeleteReport(int reportId);
    }
}