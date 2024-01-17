using AutoMapper;
using BLL.Command;
using BLL.Representation;
using DAL.Models;

namespace VoitureAdmin.Mapper
{
    public class VehiculeMapper : Profile
    {
        public VehiculeMapper()
        {
            CreateMap<Vehicule, VehiculeRepresentation>()
             .ForMember(dest => dest.idRepresentation, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.photoRepresentation, opt => opt.MapFrom(src => src.photo))
            .ForMember(dest => dest.typeRepresentation, opt => opt.MapFrom(src => src.type))
            .ForMember(dest => dest.marqueRepresentation, opt => opt.MapFrom(src => src.marque))
            .ForMember(dest => dest.kilometrageRepresentation, opt => opt.MapFrom(src => src.kilometrage))
            .ForMember(dest => dest.nombreSiegesRepresentation, opt => opt.MapFrom(src => src.nombreSieges))
            .ForMember(dest => dest.typeMoteurRepresentation, opt => opt.MapFrom(src => src.typeMoteur))
            .ForMember(dest => dest.prixRepresentation, opt => opt.MapFrom(src => src.prix))
            .ForMember(dest => dest.annonceRepresentation, opt => opt.MapFrom(src => src.annonce));

            CreateMap<VehiculeCommand, Vehicule>()
            .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.idCommand))
            .ForMember(dest => dest.photo, opt => opt.MapFrom(src => src.photoCommand))
            .ForMember(dest => dest.type, opt => opt.MapFrom(src => src.typeCommand))
            .ForMember(dest => dest.marque, opt => opt.MapFrom(src => src.marqueCommand))
            .ForMember(dest => dest.kilometrage, opt => opt.MapFrom(src => src.kilometrageCommand))
            .ForMember(dest => dest.nombreSieges, opt => opt.MapFrom(src => src.nombreSiegesCommand))
            .ForMember(dest => dest.typeMoteur, opt => opt.MapFrom(src => src.typeMoteurCommand))
            .ForMember(dest => dest.prix, opt => opt.MapFrom(src => src.prixCommand))
            .ForMember(dest => dest.annonce, opt => opt.MapFrom(src => src.annonceCommand));

        }
    }
}
