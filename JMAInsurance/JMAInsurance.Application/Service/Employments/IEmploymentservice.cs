using JMAInsurance.Models.Dto;

namespace JMAInsurance.Application.Service.Employments
{
    public interface IEmploymentService
    {
        void Create(EmploymentDto employmentDto);
        void Update(EmploymentDto employmentDto);


    }
}
