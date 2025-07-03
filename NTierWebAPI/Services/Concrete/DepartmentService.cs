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
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;
        private readonly IDataShaper<DepartmentDto> _shaper;

        public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper, IDataShaper<DepartmentDto> shaper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
            _shaper = shaper;
        }

        public async Task<DepartmentDto> CreateDepartment(DepartmentDto departmentDto)
        {
            var existingDepartmentByName = await _departmentRepository.GetDepartmentByName(departmentDto.DepartmentName, false);
            var existingDepartmentByID = await _departmentRepository.GetOneDepartmentById((int)departmentDto.DepartmentID, false);

            if (existingDepartmentByName != null && existingDepartmentByID != null)
                throw new DepartmentDuplicateException("DepartmentID", departmentDto.DepartmentID.ToString(),
                                                       "DepartmentName", departmentDto.DepartmentName);
            if (existingDepartmentByID != null)
                throw new DepartmentDuplicateException("DeapartmentID", departmentDto.DepartmentID.ToString());

            if (existingDepartmentByName != null)
                throw new DepartmentDuplicateException("DepartmentName", departmentDto.DepartmentName);

            var department = _mapper.Map<Department>(departmentDto);
            var createdDepartment = await _departmentRepository.CreateDepartment(department);
            return _mapper.Map<DepartmentDto>(createdDepartment);
        }

        public async Task<IEnumerable<DepartmentDto>> GetAllDepartments(bool trackChanges)
        {
            var departments = await _departmentRepository.GetAllDepartments(trackChanges);
            return _mapper.Map<IEnumerable<DepartmentDto>>(departments);
        }

        public async Task<(IEnumerable<ExpandoObject> departments, MetaData metaData)> GetDepartmentsByParameters(DepartmentParameters departmentParameters, bool trackChanges)
        {
            var departmentsWithMetaData = await _departmentRepository.GetDepartmentsByParameters(departmentParameters, trackChanges);

            var departmentsDto = _mapper.Map<IEnumerable<DepartmentDto>>(departmentsWithMetaData);

            var shapedData = _shaper.ShapeData(departmentsDto, departmentParameters.Fields);

            return (departments: shapedData, metaData: departmentsWithMetaData.MetaData);
        }

        public async Task<DepartmentDto> GetOneDepartmentById(int id, bool trackChanges)
        {
            var department = await _departmentRepository.GetOneDepartmentById(id, trackChanges);
            if (department == null)
            {
                throw new DepartmentNotFoundException(id);
            }
            return _mapper.Map<DepartmentDto>(department);
        }

        public async Task<DepartmentDtoForUpdate> UpdateDepartment(DepartmentDtoForUpdate departmentDto, int id)
        {
            var departmentEntity = await _departmentRepository.GetOneDepartmentById(id, true);
            if (departmentEntity == null)
            {
                throw new DepartmentNotFoundException(id);
            }
            _mapper.Map(departmentDto, departmentEntity);
            await _departmentRepository.UpdateDepartment(departmentEntity);
            return _mapper.Map<DepartmentDtoForUpdate>(departmentEntity);
        }

        public async Task DeleteDepartment(int id)
        {
            var department = await _departmentRepository.GetOneDepartmentById(id, false);
            if (department == null)
            {
                throw new DepartmentNotFoundException(id);
            }
            await _departmentRepository.DeleteDepartment(id);
        }
    }
}
