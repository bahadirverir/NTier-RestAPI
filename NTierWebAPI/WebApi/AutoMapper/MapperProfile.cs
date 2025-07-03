using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace WebApi.AutoMapper 
{ 
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<Department, DepartmentDtoForUpdate>().ReverseMap();
            
            CreateMap<Job, JobDtoForUpdate>().ReverseMap();
            CreateMap<Job, JobDto>().ReverseMap();
            
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Employee, EmployeeDtoForUpdate>().ReverseMap();

            CreateMap<UserForRegistrationDto, User>();
        }
    }
}
