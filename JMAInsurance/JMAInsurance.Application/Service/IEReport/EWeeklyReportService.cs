using AutoMapper;
using JMAInsurance.Entity;
using JMAInsurance.EntityFramwork.Repository;
using JMAInsurance.Models.Dto;

namespace JMAInsurance.Application.Service.IEReport
{
    public class EWeeklyReportService : IEWeeklyReportService
    {
        private readonly IRepository<EWeeklyReport> _repositoryEWeeklyReport;

        public EWeeklyReportService(Repository<EWeeklyReport> repositoryEWeeklyReport)
        {
            _repositoryEWeeklyReport = repositoryEWeeklyReport;
        }
        public void Create(EWeeklyReportDto eWeeklyReporttDto)
        {
            _repositoryEWeeklyReport.Create(Mapper.Map<EWeeklyReport>(eWeeklyReporttDto));
            _repositoryEWeeklyReport.Save();
        }
    }
}
