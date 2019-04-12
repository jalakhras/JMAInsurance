using AutoMapper;
using JMAInsurance.Entity;
using JMAInsurance.Models.Dto;
using JMAInsurance.Models.ViewModel;
using System.Collections.Generic;

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

                //cfg.CreateMap<IEnumerable<Applicant>, IEnumerable<ApplicantDto>>()
                //    .ReverseMap();

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

                cfg.CreateMap<EmploymentDto, EmploymentVM>()
                    .ForMember(dest => dest.Employer, opt => opt.MapFrom(src => src.Employer))
                    .ForMember(dest => dest.EmploymentType, opt => opt.MapFrom(src => src.EmploymentType))
                    .ForMember(dest => dest.GrossMonthlyIncome, opt => opt.MapFrom(src => src.GrossMonthlyIncome))
                    .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position))
                    .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                    .ReverseMap();

                cfg.CreateMap<ApplicantDto, ApplicantVM>()
                    .ForMember(dest => dest.ApplicantTracker, opt => opt.MapFrom(src => src.ApplicantTracker))
                    .ForMember(dest => dest.Dob, opt => opt.MapFrom(src => src.Dob))
                    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                    .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                    .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                    .ForMember(dest => dest.HighestEducation, opt => opt.MapFrom(src => src.HighestEducation))
                    .ForMember(dest => dest.LicenseStatus, opt => opt.MapFrom(src => src.LicenseStatus))
                    .ForMember(dest => dest.MaritalStatus, opt => opt.MapFrom(src => src.MaritalStatus))
                    .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                    .ForMember(dest => dest.YearsLicensed, opt => opt.MapFrom(src => src.YearsLicensed))
                    .ReverseMap();

                //cfg.CreateMap<IEnumerable<ApplicantDto>, IEnumerable<ApplicantVM>>()
                //    .ReverseMap();

                cfg.CreateMap<EmploymentDto, EmploymentVM>()
                    .ForMember(dest => dest.Employer, opt => opt.MapFrom(src => src.Employer))
                    .ForMember(dest => dest.EmploymentType, opt => opt.MapFrom(src => src.EmploymentType))
                    .ForMember(dest => dest.GrossMonthlyIncome, opt => opt.MapFrom(src => src.GrossMonthlyIncome))
                    .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position))
                    .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                    .ReverseMap();

                cfg.CreateMap<ProductsDto, ProductsVM>()
                    .ForMember(dest => dest.Collision, opt => opt.MapFrom(src => src.Collision))
                    .ForMember(dest => dest.Comprehensive, opt => opt.MapFrom(src => src.Comprehensive))
                    .ForMember(dest => dest.DriverRewards, opt => opt.MapFrom(src => src.DriverRewards))
                    .ForMember(dest => dest.Liability, opt => opt.MapFrom(src => src.Liability))
                    .ForMember(dest => dest.LoanPayoff, opt => opt.MapFrom(src => src.LoanPayoff))
                    .ForMember(dest => dest.PropertyDamage, opt => opt.MapFrom(src => src.PropertyDamage))
                    .ForMember(dest => dest.Rental, opt => opt.MapFrom(src => src.Rental))
                    .ForMember(dest => dest.RoadSideAssistance, opt => opt.MapFrom(src => src.RoadSideAssistance))
                    .ReverseMap();

                cfg.CreateMap<ProgressDto, ProgressVM>()
                    .ForMember(dest => dest.CurrentStage, opt => opt.MapFrom(src => src.CurrentStage))
                    .ForMember(dest => dest.HighestStage, opt => opt.MapFrom(src => src.HighestStage))
                    .ReverseMap();

                cfg.CreateMap<VehicleDto, VehicleVM>()
                   .ForMember(dest => dest.BodyType, opt => opt.MapFrom(src => src.BodyType))
                   .ForMember(dest => dest.Make, opt => opt.MapFrom(src => src.Make))
                   .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model))
                   .ForMember(dest => dest.OwnLease, opt => opt.MapFrom(src => src.OwnLease))
                   .ForMember(dest => dest.PrimaryUse, opt => opt.MapFrom(src => src.PrimaryUse))
                   .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Year))
                   .ReverseMap();

                cfg.CreateMap<ErrorLogDto, ErrorLog>()
                   .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                   .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Message))
                   .ForMember(dest => dest.SessionId, opt => opt.MapFrom(src => src.SessionId))
                   .ForMember(dest => dest.StackTrace, opt => opt.MapFrom(src => src.StackTrace))
                   .ForMember(dest => dest.TargetedResult, opt => opt.MapFrom(src => src.TargetedResult))
                   .ForMember(dest => dest.Timestamp, opt => opt.MapFrom(src => src.Timestamp))
                   .ForMember(dest => dest.UserAgent, opt => opt.MapFrom(src => src.UserAgent))
                   .ReverseMap();






            });
        }
    }
}
