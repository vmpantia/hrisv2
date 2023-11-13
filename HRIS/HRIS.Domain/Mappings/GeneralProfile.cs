using AutoMapper;
using HRIS.Domain.Models.Dtos;
using HRIS.Domain.Models.Entities;
using HRIS.Domain.Models.Entities.Versions;

namespace HRIS.Domain.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Employee, EmployeeVersion>()
                .ReverseMap();

            CreateMap<SaveEmployeeDto, Employee>();
        }
    }
}
