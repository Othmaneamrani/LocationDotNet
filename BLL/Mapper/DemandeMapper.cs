using AutoMapper;
using BLL.Command;
using BLL.Representation;
using DAL.Models;

namespace BLL.Mapper
{
    public class DemandeMapper : Profile
    {
        public DemandeMapper() 
        { 
            CreateMap<Demande, DemandeRepresentation>().ForMember(dest => dest.idRepresentation, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.dateDebutRepresentation, opt => opt.MapFrom(src => src.dateDebut))
            .ForMember(dest => dest.dateFinRepresentation, opt => opt.MapFrom(src => src.dateFin))
            .ForMember(dest => dest.prixTotalRepresentation, opt => opt.MapFrom(src => src.prixTotal))
            .ForMember(dest => dest.compteIdRepresentation, opt => opt.MapFrom(src => src.compteId))
            .ForMember(dest => dest.compteRepresentation, opt => opt.MapFrom(src => src.compte))
            .ForMember(dest => dest.vehiculeIdRepresentation, opt => opt.MapFrom(src => src.vehiculeId))
            .ForMember(dest => dest.vehiculeRepresentation, opt => opt.MapFrom(src => src.vehicule));

            CreateMap<DemandeCommand, Demande>()
            .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.idCommand))
            .ForMember(dest => dest.dateDebut, opt => opt.MapFrom(src => src.dateDebutCommand))
            .ForMember(dest => dest.dateFin, opt => opt.MapFrom(src => src.dateFinCommand))
            .ForMember(dest => dest.prixTotal, opt => opt.MapFrom(src => src.prixTotalCommand))
            .ForMember(dest => dest.compteId, opt => opt.MapFrom(src => src.compteIdCommand))
            .ForMember(dest => dest.compte, opt => opt.MapFrom(src => src.compteCommand))
            .ForMember(dest => dest.vehiculeId, opt => opt.MapFrom(src => src.vehiculeIdCommand))
            .ForMember(dest => dest.vehicule, opt => opt.MapFrom(src => src.vehiculeCommand));
        }
    }
}
