using AutoMapper;
using Bibio.API.DTO;
using DOMAIN.Entities;

namespace Bibio.API.AutoMapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
             CreateMap<Adherant, AdherantDto>().ReverseMap();
           
             CreateMap<ouvrage, OuvrageDto>().ReverseMap();
             CreateMap<emprunt, EmpruntDto>().ReverseMap();
            CreateMap<EmpruntDto, emprunt>().ReverseMap();
            CreateMap<Adherant, EmpruntDto>().ForMember(o => o.AdherantID, i => i.MapFrom(s => s.Id));
            CreateMap<ouvrage, EmpruntDto>().ForMember(o => o.OuvrageID, i => i.MapFrom(s => s.Id));
        }
    }
}
