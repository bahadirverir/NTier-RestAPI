using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Abstract;
using Repositories.RepositoryExtensions;

namespace Repositories.Concrete
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;
        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Department> CreateDepartment(Department department)
        {
            await _context.Departments.AddAsync(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task<IEnumerable<Department>> GetAllDepartments(bool trackChanges)
        {
            return await (trackChanges 
                ? _context.Departments
                : _context.Departments.AsNoTracking())
                .OrderBy(d => d.DepartmentID)
                .ToListAsync();
        }

        public async Task<PagedList<Department>> GetDepartmentsByParameters(DepartmentParameters departmentParameters, bool trackChanges)
        {
            var departments = trackChanges
                ? _context.Departments
                : _context.Departments.AsNoTracking();

            departments = departments
                .Search(departmentParameters.DepartmentName)
                .Sort(departmentParameters.OrderBy);  
            
            return await PagedList<Department>.ToPagedListAsync(
                departments,
                departmentParameters.PageNumber,
                departmentParameters.PageSize);
        } 

        public async Task<Department> GetOneDepartmentById(int id, bool trackChanges)
        {
            return await (trackChanges
                ? _context.Departments
                : _context.Departments.AsNoTracking())
                .FirstOrDefaultAsync(d => d.DepartmentID == id);
        }

        public async Task<Department> UpdateDepartment(Department department)
        {
            _context.Departments.Update(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task DeleteDepartment(int id)
        {
            var deletedDepartment = await GetOneDepartmentById(id, false);
            _context.Departments.Remove(deletedDepartment);
            await _context.SaveChangesAsync();
        }

        public async Task<Department> GetDepartmentByName(string departmentName, bool trackChanges)
        {
            return await (trackChanges
                ? _context.Departments
                : _context.Departments.AsNoTracking())
                .FirstOrDefaultAsync(d => d.DepartmentName.ToLower() == departmentName.ToLower());
        }    
    }
} 