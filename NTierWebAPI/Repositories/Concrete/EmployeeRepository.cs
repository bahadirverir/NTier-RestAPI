using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Abstract;
using Repositories.RepositoryExtensions;

namespace Repositories.Concrete
{ 
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;
        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> CreateEmployee(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee;
        }
        
        public async Task<IEnumerable<Employee>> GetAllEmployees(bool trackChanges)
        {
            return await (trackChanges
                ? _context.Employees
                : _context.Employees.AsNoTracking())
                .ToListAsync();
        }

        public async Task<PagedList<Employee>> GetEmployeesByParameters(EmployeeParameters employeeParameters, bool trackChanges)
        {
            var employees = trackChanges
                ? _context.Employees
                : _context.Employees.AsNoTracking();

             employees = employees
                .FilterEmployees(employeeParameters)
                .Search(employeeParameters.FirstName, employeeParameters.LastName)
                .Sort(employeeParameters.OrderBy);
            
            return await PagedList<Employee>.ToPagedListAsync(
                employees,
                employeeParameters.PageNumber,
                employeeParameters.PageSize);
        }
        
        public async Task<Employee> GetOneEmployeeById(int id, bool trackChanges)
        {
            return await (trackChanges
                ? _context.Employees
                : _context.Employees.AsNoTracking())
                .FirstOrDefaultAsync(e => e.EmployeeID == id);
        }
        
        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
            return employee;
        }
        
        public async Task DeleteEmployee(int id)
        {
            var deletedEmployee = await GetOneEmployeeById(id, false);
            _context.Employees.Remove(deletedEmployee);
            await _context.SaveChangesAsync();
        }
    }
}