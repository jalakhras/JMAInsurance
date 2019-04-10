using AutoMapper;
using JMAInsurance.Models.Dto;
using JMAInsurance.ViewModels;
using JMAInsurance.Web.ViewModels;

namespace JMAInsurance.Web.ConfigurationMapper
{
    public class AutoMapperConfiguration
    {
        public static void Initialize()
        {
            Mapper.Reset();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ApplicantDto, ApplicantVM>()
                    .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                    .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                    .ForMember(dest => dest.Dob, opt => opt.MapFrom(src => src.Dob))
                    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                    .ForMember(dest => dest.HighestEducation, opt => opt.MapFrom(src => src.HighestEducation))
                    .ForMember(dest => dest.LicenseStatus, opt => opt.MapFrom(src => src.LicenseStatus))
                    .ForMember(dest => dest.MaritalStatus, opt => opt.MapFrom(src => src.MaritalStatus))
                    .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                    .ForMember(dest => dest.YearsLicensed, opt => opt.MapFrom(src => src.YearsLicensed))
                    .ReverseMap();

                cfg.CreateMap<EmploymentDto, EmploymentVM>()
                    .ForMember(dest => dest.Employer, opt => opt.MapFrom(src => src.Employer))
                    .ForMember(dest => dest.EmploymentType, opt => opt.MapFrom(src => src.EmploymentType))
                    .ForMember(dest => dest.GrossMonthlyIncome, opt => opt.MapFrom(src => src.GrossMonthlyIncome))
                    .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position))
                    .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                    .ReverseMap();

            });
        }
    }
}