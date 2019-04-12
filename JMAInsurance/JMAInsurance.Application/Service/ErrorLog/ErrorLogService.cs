using AutoMapper;
using JMAInsurance.EntityFramwork.Repository;
using JMAInsurance.Models.Dto;

namespace JMAInsurance.Application.Service.ErrorLog
{
  public  class ErrorLogService : IErrorLogService
    {
        private readonly IRepository<Entity.ErrorLog> _repositoryErrorLog;

        public ErrorLogService(IRepository<Entity.ErrorLog> repositoryErrorLog)
        {
            _repositoryErrorLog = repositoryErrorLog;
        }
        public void Create(ErrorLogDto errorLogDto)
        {
            _repositoryErrorLog.Create(Mapper.Map<Entity.ErrorLog>(errorLogDto));
            _repositoryErrorLog.Save();
        }
    }
}
