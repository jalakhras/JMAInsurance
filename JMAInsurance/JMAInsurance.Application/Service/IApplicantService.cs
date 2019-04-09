using JMAInsurance.EntityFramwork.Extensibility.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMAInsurance.Application.Service
{
    public interface IApplicantService : IDependency
    {
        void GetAll();
    }
}
