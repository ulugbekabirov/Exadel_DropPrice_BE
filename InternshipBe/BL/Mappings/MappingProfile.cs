using AutoMapper;
using BL.DTO;
using DAL.Entities;

namespace BL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Town, TownDTO>()
                .ForMember(t => t.TownName, source => source.MapFrom(s => s.Name));
            CreateMap<TownDTO, Town>()
                .ForMember(t => t.Name, source => source.MapFrom(s => s.TownName));
        }
    }
}
