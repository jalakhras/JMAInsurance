using JMAInsurance.Models.Dto;

namespace JMAInsurance.Application.Service.Vehicle
{
    public interface IVehicleService
    {
        void Create(VehicleDto vehicleDto);
        void Update(VehicleDto vehicleDto);
    }
}
