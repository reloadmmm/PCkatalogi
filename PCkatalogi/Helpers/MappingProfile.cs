using AutoMapper;
using PCkatalogi.DTOs;
using PCkatalogi.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PCkatalogi.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();

            CreateMap<Manufacturer, ManufacturerDto>().ReverseMap();
            CreateMap<CreateManufacturerDto, Manufacturer>();
            CreateMap<UpdateManufacturerDto, Manufacturer>();

            CreateMap<Protocol, ProtocolDto>().ReverseMap();
            CreateMap<CreateProtocolDto, Protocol>();
            CreateMap<UpdateProtocolDto, Protocol>();

            CreateMap<Component, ComponentDto>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.Manufacturer, opt => opt.MapFrom(src => src.Manufacturer))
                .ForMember(dest => dest.Protocols, opt => opt.MapFrom(src => src.Protocols));

            CreateMap<CreateComponentDto, Component>();
            CreateMap<UpdateComponentDto, Component>();

            CreateMap<CompatibilityRule, CompatibilityRuleDto>()
                .ForMember(dest => dest.SourceComponent, opt => opt.MapFrom(src => src.SourceComponent))
                .ForMember(dest => dest.TargetComponent, opt => opt.MapFrom(src => src.TargetComponent))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category));

            CreateMap<CreateCompatibilityRuleDto, CompatibilityRule>();
            CreateMap<UpdateCompatibilityRuleDto, CompatibilityRule>();
        }
    }
}