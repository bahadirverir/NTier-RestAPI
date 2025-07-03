using System.Dynamic;
using Entities.DataTransferObjects;
using Entities.RequestFeatures;

namespace Services.Abstract
{   
    public interface IDepartmentService
    {
        Task<(IEnumerable<ExpandoObject> departments, MetaData metaData)> GetDepartmentsByParameters(DepartmentParameters departmentParameters, bool trackChanges);
        Task<IEnumerable<DepartmentDto>> GetAllDepartments(bool trackChanges);
        Task<DepartmentDto> GetOneDepartmentById(int id, bool trackChanges);
        Task<DepartmentDto> CreateDepartment(DepartmentDto departmentDto);
        Task<DepartmentDtoForUpdate> UpdateDepartment(DepartmentDtoForUpdate departmentDto, int id);
        Task DeleteDepartment(int id);
    }
}