using Entities.Models;
using Entities.RequestFeatures;

namespace Repositories.Abstract
{ 
    public interface IEmployeeRepository
    {
        Task<PagedList<Employee>> GetEmployeesByParameters(EmployeeParameters employeeParameters, bool trackChanges);
        Task<IEnumerable<Employee>> GetAllEmployees(bool trackChanges);
        Task<Employee> GetOneEmployeeById(int id, bool trackChanges);
        Task<Employee> CreateEmployee(Employee employee);
        Task<Employee> UpdateEmployee(Employee employee);
        Task DeleteEmployee(int id);
    } 
}