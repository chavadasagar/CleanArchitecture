using Application.Interface;
using Core.Dto;
using Core.Entities;
using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DatabaseHelper _databaseHelper;

        public EmployeeRepository(DatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
        }

        public async Task<int> AddAsync(Employee entity)
        {
            var param = new DynamicParameters();
            param.Add("@Name", entity.Name);
            param.Add("@Email", entity.Email);
            param.Add("@MobileNumber", entity.MobileNumber);
            param.Add("@DOB_", entity.DOB);
            param.Add("@CountryId", entity.CountryId);
            param.Add("@StateId", entity.StateId);
            param.Add("@IsActive", entity.IsActive);
            return await _databaseHelper.ExecuteNonQuery("SP_InsertEmploye", param);
        }

        public async Task<int> DeleteAsync(int id)
        {
            var param = new DynamicParameters();
            param.Add("@Id", id);
            return await _databaseHelper.ExecuteScalar<int>("SP_DeleteEmployees", param);
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            var param = new DynamicParameters();
            return await _databaseHelper.ExecuteQuery<Employee>("SP_GetAllEmployee", param);
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            var param = new DynamicParameters();
            param.Add("@Id", id);
            return await _databaseHelper.ExecuteFirstQuery<Employee>("SP_GetEmployeesById", param);
        }

        public async Task<IEnumerable<EmployeeUpcomingBirthdaysDto>> UpcomingBirthdays()
        {
            var param = new DynamicParameters();
            return await _databaseHelper.ExecuteQuery<EmployeeUpcomingBirthdaysDto>("SP_upcoming_birthdays", param);
        }

        public async Task<int> UpdateAsync(Employee entity)
        {
            var param = new DynamicParameters();
            param.Add("@Id", entity.Id);
            param.Add("@Name", entity.Name);
            param.Add("@DOB_", entity.DOB);
            param.Add("@Email", entity.Email);
            param.Add("@MobileNumber", entity.MobileNumber);
            param.Add("@CountryId", entity.CountryId);
            param.Add("@StateId", entity.StateId);
            param.Add("@IsActive", entity.IsActive);
            return await _databaseHelper.ExecuteNonQuery("SP_UpdateEmployees", param);
        }
    }
}
