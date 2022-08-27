using CleanArchitecture.Application.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Contratcs.Identity
{
    public interface IUserService
    {
        Task<List<Employee>> GetEmployees();
    }
}
