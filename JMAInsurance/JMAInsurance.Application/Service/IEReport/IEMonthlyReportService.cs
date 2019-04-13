using JMAInsurance.Entity;
using JMAInsurance.Models.Dto;

namespace JMAInsurance.Application.Service.IEReport
{
    public interface IEMonthlyReportService
    {
        void Create(EMonthlyReportDto eMonthlyReportDto);
    }
}
