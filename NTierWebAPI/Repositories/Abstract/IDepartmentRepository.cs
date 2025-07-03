using Entities.Models;
using Entities.RequestFeatures;

namespace Repositories.Abstract
{
    public interface IDepartmentRepository
    {
        Task<PagedList<Department>> GetDepartmentsByParameters(DepartmentParameters departmentParameters, bool trackChanges);
        Task<IEnumerable<Department>> GetAllDepartments(bool trackChanges);
        Task<Department> GetOneDepartmentById(int id, bool trackChanges);
        Task<Department> CreateDepartment(Department department);
        Task<Department> UpdateDepartment(Department department);
        Task DeleteDepartment(int id);
        Task<Department> GetDepartmentByName(string departmentName, bool trackChanges);
    }
}