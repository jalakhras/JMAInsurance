using JMAInsurance.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMAInsurance.Application.Service.ErrorLog
{
    public interface IErrorLogService
    {
        void Create(ErrorLogDto errorLogDto);
    }


   
}
