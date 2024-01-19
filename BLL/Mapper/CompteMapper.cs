using AutoMapper;
using BLL.Command;
using BLL.Representation;
using DAL.Models;

namespace BLL.Mapper
{
    public class CompteMapper : Profile
    {
        public CompteMapper()
        {
            CreateMap<Compte, CompteRepresentation>().ForMember(dest => dest.idRepresentation, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.usernameRepresentation, opt => opt.MapFrom(src => src.username))
            .ForMember(dest => dest.passwordRepresentation, opt => opt.MapFrom(src => src.password))
            .ForMember(dest => dest.nomRepresentation, opt => opt.MapFrom(src => src.nom))
            .ForMember(dest => dest.prenomRepresentation, opt => opt.MapFrom(src => src.prenom))
            .ForMember(dest => dest.ageRepresentation, opt => opt.MapFrom(src => src.age))
            .ForMember(dest => dest.emailRepresentation, opt => opt.MapFrom(src => src.email))
            .ForMember(dest => dest.cinRepresentation, opt => opt.MapFrom(src => src.cin))
            .ForMember(dest => dest.telephoneRepresentation, opt => opt.MapFrom(src => src.telephone));

            CreateMap<CompteCommand, Compte>()
            .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.idCommand))
            .ForMember(dest => dest.username, opt => opt.MapFrom(src => src.usernameCommand))
            .ForMember(dest => dest.password, opt => opt.MapFrom(src => src.passwordCommand))
            .ForMember(dest => dest.nom, opt => opt.MapFrom(src => src.nomCommand))
            .ForMember(dest => dest.prenom, opt => opt.MapFrom(src => src.prenomCommand))
            .ForMember(dest => dest.age, opt => opt.MapFrom(src => src.ageCommand))
            .ForMember(dest => dest.email, opt => opt.MapFrom(src => src.emailCommand))
            .ForMember(dest => dest.cin, opt => opt.MapFrom(src => src.cinCommand))
            .ForMember(dest => dest.telephone, opt => opt.MapFrom(src => src.telephoneCommand));

        }
    }
}
