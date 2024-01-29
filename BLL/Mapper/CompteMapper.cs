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
            CreateMap<Compte, CompteRepresentation>()
            .ForMember(dest => dest.idRepresentation, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.usernameRepresentation, opt => opt.MapFrom(src => src.username))
            .ForMember(dest => dest.passwordRepresentation, opt => opt.MapFrom(src => src.password))
            .ForMember(dest => dest.emailRepresentation, opt => opt.MapFrom(src => src.email))
            .ForMember(dest => dest.telephoneRepresentation, opt => opt.MapFrom(src => src.telephone));

            CreateMap<CompteCommand, Compte>()
            .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.idCommand))
            .ForMember(dest => dest.username, opt => opt.MapFrom(src => src.usernameCommand))
            .ForMember(dest => dest.password, opt => opt.MapFrom(src => src.passwordCommand))
            .ForMember(dest => dest.email, opt => opt.MapFrom(src => src.emailCommand))
            .ForMember(dest => dest.telephone, opt => opt.MapFrom(src => src.telephoneCommand));


            CreateMap<Compte, CompteCommand>()
            .ForMember(dest => dest.idCommand, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.usernameCommand, opt => opt.MapFrom(src => src.username))
            .ForMember(dest => dest.passwordCommand, opt => opt.MapFrom(src => src.password))
            .ForMember(dest => dest.emailCommand, opt => opt.MapFrom(src => src.email))
            .ForMember(dest => dest.telephoneCommand, opt => opt.MapFrom(src => src.telephone));


            CreateMap<CompteCommand, CompteRepresentation>()
            .ForMember(dest => dest.idRepresentation, opt => opt.MapFrom(src => src.idCommand))
            .ForMember(dest => dest.usernameRepresentation, opt => opt.MapFrom(src => src.usernameCommand))
            .ForMember(dest => dest.passwordRepresentation, opt => opt.MapFrom(src => src.passwordCommand))
            .ForMember(dest => dest.emailRepresentation, opt => opt.MapFrom(src => src.emailCommand))
            .ForMember(dest => dest.telephoneRepresentation, opt => opt.MapFrom(src => src.telephoneCommand));


            CreateMap<CompteRepresentation, CompteCommand > ()
        .ForMember(dest => dest.idCommand, opt => opt.MapFrom(src => src.idRepresentation))
        .ForMember(dest => dest.usernameCommand, opt => opt.MapFrom(src => src.usernameRepresentation))
        .ForMember(dest => dest.passwordCommand, opt => opt.MapFrom(src => src.passwordRepresentation))
        .ForMember(dest => dest.emailCommand, opt => opt.MapFrom(src => src.emailRepresentation))
        .ForMember(dest => dest.telephoneCommand, opt => opt.MapFrom(src => src.telephoneRepresentation));


        }
    }
}
