using AutoMapper;
using HRIS.Domain.Models.Entities;

namespace HRIS.Domain.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Employee, EmployeeVersion>()
                .ReverseMap();
        }
    }
}
