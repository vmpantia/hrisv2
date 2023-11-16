using AutoMapper;
using HRIS.Domain.Extensions;
using HRIS.Domain.Models.Dtos;
using HRIS.Domain.Models.Entities;
using HRIS.Domain.Models.Entities.Versions;
using HRIS.Domain.Utils;

namespace HRIS.Domain.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Employee, EmployeeVersion>()
                .ReverseMap();
            CreateMap<Contact, ContactVersion>()
                .ReverseMap();
            CreateMap<Address, AddressVersion>()
                .ReverseMap();


            CreateMap<SaveEmployeeDto, Employee>()
                .ForMember(dst => dst.Contacts, opt => opt.Ignore())
                .ForMember(dst => dst.Addresses, opt => opt.Ignore());
            CreateMap<SaveContactDto, Contact>();
            CreateMap<SaveAddressDto, Address>();

            CreateMap<Employee, EmployeeLiteDto>()
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.GetFullName()))
                .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status.GetDescription()));

            CreateMap<Employee, EmployeeDto>()
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.GetFullName()))
                .ForMember(dst => dst.Age, opt => opt.MapFrom(src => DateUtil.GetDayDifference(src.BirthDate)))
                .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status.GetDescription()));

            CreateMap<Contact, ContactDto>()
                .ForMember(dst => dst.Type, opt => opt.MapFrom(src => src.Type.GetDescription()))
                .ForMember(dst => dst.Category, opt => opt.MapFrom(src => src.IsPersonal ? "Personal" : "Corporate"))
                .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status.GetDescription()));

            CreateMap<Address, AddressDto>()
                .ForMember(dst => dst.Address, opt => opt.MapFrom(src => src.GetFullAddress()))
                .ForMember(dst => dst.Type, opt => opt.MapFrom(src => src.Type.GetDescription()))
                .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status.GetDescription()));
        }
    }
}
