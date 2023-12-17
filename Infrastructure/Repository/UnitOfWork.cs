using Application.Interface;

namespace Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        public UnitOfWork(IEmployeeRepository EmployeeRepository)
        {
            this.EmployeeRepository = EmployeeRepository;
        }

        public IEmployeeRepository EmployeeRepository { get; }
    }
}
