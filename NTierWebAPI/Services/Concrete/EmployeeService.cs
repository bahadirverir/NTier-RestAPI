using System.Dynamic;
using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Entities.RequestFeatures;
using Repositories.Abstract;
using Services.Abstract;

namespace Services.Concrete
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly IDataShaper<EmployeeDto> _shaper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper, IDataShaper<EmployeeDto> shaper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _shaper = shaper;
        }

        public async Task<EmployeeDto> CreateEmployee(EmployeeDto employeeDto)
        {
            var existingEmployee = await _employeeRepository.GetOneEmployeeById((int)employeeDto.EmployeeID, false);
            if (existingEmployee != null)
                throw new EmployeeDuplicateException((int)employeeDto.EmployeeID);

            var employee = _mapper.Map<Employee>(employeeDto); 
            var createdEmployee = await _employeeRepository.CreateEmployee(employee);
            return _mapper.Map<EmployeeDto>(createdEmployee); 
        }
        
        public async Task<IEnumerable<EmployeeDto>> GetAllEmployees(bool trackChanges)
        {
            var employees = await _employeeRepository.GetAllEmployees(trackChanges);
            return _mapper.Map<IEnumerable<EmployeeDto>>(employees);        
        }

        public async Task<(IEnumerable<ExpandoObject> employees, MetaData metaData)> GetEmployeesByParameters(EmployeeParameters employeeParameters, bool trackChanges)
        {
            var employeesWithMetaData = await _employeeRepository.GetEmployeesByParameters(employeeParameters, trackChanges);

            var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employeesWithMetaData);

            var shapedData = _shaper.ShapeData(employeesDto, employeeParameters.Fields);

            return (employees : shapedData, metaData: employeesWithMetaData.MetaData);
        }
        
        public async Task<EmployeeDto> GetOneEmployeeById(int id, bool trackChanges)
        {
            var employee = await _employeeRepository.GetOneEmployeeById(id, trackChanges);
            if(employee == null)
            {
                throw new EmployeeNotFoundException(id);
            }
            return _mapper.Map<EmployeeDto>(employee);
        }

        public async Task<EmployeeDtoForUpdate> UpdateEmployee(EmployeeDtoForUpdate employeeDto, int id)
        {
            var employeeEntity = await _employeeRepository.GetOneEmployeeById(id, true); 
            if (employeeEntity == null)
            {
                throw new EmployeeNotFoundException(id);
            }
            _mapper.Map(employeeDto, employeeEntity); 
            await _employeeRepository.UpdateEmployee(employeeEntity); 
            return _mapper.Map<EmployeeDtoForUpdate>(employeeEntity);
        }

        public async Task DeleteEmployee(int id)
        {
            var employee = await _employeeRepository.GetOneEmployeeById(id, false);
            if(employee == null)
            {
                throw new EmployeeNotFoundException(id);
            }
            await _employeeRepository.DeleteEmployee(id);
        } 
    }
}