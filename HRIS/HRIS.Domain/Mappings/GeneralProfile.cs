using AutoMapper;
using HRIS.Domain.Extensions;
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

            CreateMap<Employee, EmployeeLiteDto>()
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.GetFullName()))
                .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status.GetDescription()));
        }
    }
}
