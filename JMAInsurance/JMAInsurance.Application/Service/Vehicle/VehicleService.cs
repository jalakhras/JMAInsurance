using AutoMapper;
using JMAInsurance.EntityFramwork.Repository;
using JMAInsurance.Models.Dto;

namespace JMAInsurance.Application.Service.Vehicle
{
    public class VehicleService : IVehicleService
    {
        private readonly IRepository<Entity.Vehicle> _repositoryVehicle;
        public VehicleService(IRepository<Entity.Vehicle> repositoryVehicle)
        {
            _repositoryVehicle = repositoryVehicle;
        }
        public void Create(VehicleDto vehicleDto)
        {
            _repositoryVehicle.Create(Mapper.Map<Entity.Vehicle>(vehicleDto));
            _repositoryVehicle.Save();
        }
        public void Update(VehicleDto vehicleDto)
        {
            _repositoryVehicle.Update(Mapper.Map<Entity.Vehicle>(vehicleDto));
            _repositoryVehicle.Save();
        }

    }
}
