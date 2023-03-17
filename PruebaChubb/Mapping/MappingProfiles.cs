using AutoMapper;
using PruebaChubb.CI.Entities.Parameter;
using PruebaChubb.CI.Entities.Repository;
using PruebaChubb.Data.Context;

namespace PruebaChubb.API.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Ruletum,Ruleta>().ReverseMap();
            CreateMap<Ruletum, RuletaParameter>().ReverseMap();
            CreateMap<ApuestaParameter, DetalleApuestum>().ReverseMap();
        }
     }
}
