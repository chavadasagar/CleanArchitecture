using Application.Common;
using Core.Dto;
using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IEmployeeRepository : IGenericRepository<Employee>, IScopedService
    {
        public Task<IEnumerable<EmployeeUpcomingBirthdaysDto>> UpcomingBirthdays();
    }
}
