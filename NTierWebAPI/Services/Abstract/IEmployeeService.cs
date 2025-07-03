using System.Dynamic;
using Entities.DataTransferObjects;
using Entities.RequestFeatures;

namespace Services.Abstract
{ 
    public interface IEmployeeService
    {
        Task<(IEnumerable<ExpandoObject> employees, MetaData metaData)> GetEmployeesByParameters(EmployeeParameters employeeParameters, bool trackChanges);
        Task<IEnumerable<EmployeeDto>> GetAllEmployees(bool trackChanges);
        Task<EmployeeDto> GetOneEmployeeById(int id, bool trackChanges);
        Task<EmployeeDto> CreateEmployee(EmployeeDto employeeDto);
        Task<EmployeeDtoForUpdate> UpdateEmployee(EmployeeDtoForUpdate employeeDto, int id);
        Task DeleteEmployee(int id);
    }
}