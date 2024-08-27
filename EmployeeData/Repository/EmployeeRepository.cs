using EmployeeDapper.Data.DbAccess;
using EmployeeDapper.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDapper.Data.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ISqlDataAccess _db;

        public EmployeeRepository(ISqlDataAccess db)
        {
            _db = db;
        }
        public async Task<bool> AddAsync(Employee employee)
        {
            try
            {
                await _db.SaveData("sp_create_employee",new {employee.FirstName, employee.LastName,
                    employee.Email,employee.PhoneNumber, 
                    employee.DateOfBirth, employee.Gender,
                    employee.Age, employee.Address,
                    employee.Country, employee.Department, 
                    employee.Position, employee.JoiningDate, 
                    employee.Salary, employee.EmploymentStatus});

                return true;

            }
            catch(Exception ex) 
            { 
                return false;
            }
        }

        public async Task<Employee?> GetByIdAsync(int EmployeeID)
        {
           IEnumerable<Employee> result= await _db.GetData<Employee,dynamic>("sp_get_employee",new {EmployeeID});
            return result.FirstOrDefault();
        }
        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            string query ="sp_get_employees";
            return await _db.GetData<Employee, dynamic>(query, new {});
           
        }

     
        public async Task<bool> UpdateAsync(Employee employee)
        {
            try
            {
                await _db.SaveData("sp_update_employee", employee);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int EmployeeID)
        {
            try
            {
                await _db.SaveData("sp_delete_employee", new { EmployeeID });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
