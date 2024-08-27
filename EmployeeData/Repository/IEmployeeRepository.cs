using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeDapper.Data.Models;

namespace EmployeeDapper.Data.Repository
{
    public interface IEmployeeRepository
    {

        Task<bool> AddAsync(Employee employee);
        Task<bool> UpdateAsync(Employee employee);
        Task<bool> DeleteAsync(int EmployeeID);
        Task<Employee?> GetByIdAsync(int EmployeeID);
        Task<IEnumerable<Employee>> GetAllAsync();

    }
}
