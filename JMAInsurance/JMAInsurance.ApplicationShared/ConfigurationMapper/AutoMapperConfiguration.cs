using AutoMapper;
using JMAInsurance.Entity;
using JMAInsurance.Models.Dto;

namespace JMAInsurance.ApplicationShared.ConfigurationMapper
{
    public class AutoMapperConfiguration
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Applicant, ApplicantDto>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Addresses, opt => opt.MapFrom(src => src.Addresses))
                    .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                    .ForMember(dest => dest.ApplicantTracker, opt => opt.MapFrom(src => src.ApplicantTracker))
                    .ForMember(dest => dest.Dob, opt => opt.MapFrom(src => src.Dob))
                    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                    .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                    .ForMember(dest => dest.HighestEducation, opt => opt.MapFrom(src => src.HighestEducation))
                    .ForMember(dest => dest.LicenseStatus, opt => opt.MapFrom(src => src.LicenseStatus))
                    .ForMember(dest => dest.MaritalStatus, opt => opt.MapFrom(src => src.MaritalStatus))
                    //.ForMember(dest => dest.MaritalStatusId, opt => opt.MapFrom(src => src.MaritalStatusId))
                    .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                    .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products))
                    .ForMember(dest => dest.Vehicle, opt => opt.MapFrom(src => src.Vehicle))
                    .ForMember(dest => dest.WorkFlowStage, opt => opt.MapFrom(src => src.WorkFlowStage))
                    .ForMember(dest => dest.YearsLicensed, opt => opt.MapFrom(src => src.YearsLicensed))
                   
                    .ReverseMap();

                cfg.CreateMap<Employment, EmploymentDto>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.EmploymentType, opt => opt.MapFrom(src => src.EmploymentType))
                    .ForMember(dest => dest.Employer, opt => opt.MapFrom(src => src.Employer))
                    .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position))
                    .ForMember(dest => dest.GrossMonthlyIncome, opt => opt.MapFrom(src => src.GrossMonthlyIncome))
                    .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                    .ForMember(dest => dest.IsPrimary, opt => opt.MapFrom(src => src.IsPrimary))
                    .ForMember(dest => dest.ApplicantId, opt => opt.MapFrom(src => src.ApplicantId))
                    .ForMember(dest => dest.Applicant, opt => opt.MapFrom(src => src.Applicant))
                    .ReverseMap();






            });
        }
    }
}
