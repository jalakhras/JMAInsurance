using AutoMapper;
using JMAInsurance.Entity;
using JMAInsurance.EntityFramwork.Repository;
using JMAInsurance.Models.Dto;

namespace JMAInsurance.Application.Service.IEReport
{
    public class EMonthlyReportService : IEMonthlyReportService
    {
        private readonly IRepository<EMonthlyReport> _repositoryEMonthlyReport;

        public EMonthlyReportService(Repository<EMonthlyReport> repositoryEMonthlyReport)
        {
            _repositoryEMonthlyReport = repositoryEMonthlyReport;
        }
        public void Create(EMonthlyReportDto eMonthlyReportDto)
        {
            _repositoryEMonthlyReport.Create(Mapper.Map<EMonthlyReport>(eMonthlyReportDto));
            _repositoryEMonthlyReport.Save();
        }
    }
}
