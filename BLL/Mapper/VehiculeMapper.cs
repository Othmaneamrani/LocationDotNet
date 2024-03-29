﻿using AutoMapper;
using BLL.Command;
using BLL.Representation;
using DAL.Models;

namespace BLL.Mapper
{
    public class VehiculeMapper : Profile
    {
        public VehiculeMapper()
        {
            CreateMap<Vehicule, VehiculeRepresentation>()
            .ForMember(dest => dest.idRepresentation, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.photoRepresentation, opt => opt.MapFrom(src => src.photo))
            .ForMember(dest => dest.marqueRepresentation, opt => opt.MapFrom(src => src.marque))
            .ForMember(dest => dest.typeMoteurRepresentation, opt => opt.MapFrom(src => src.typeMoteur))
            .ForMember(dest => dest.prixRepresentation, opt => opt.MapFrom(src => src.prix))
            .ForMember(dest => dest.estDispoRepresentation, opt => opt.MapFrom(src => src.estDispo))
            .ForMember(dest => dest.promoRepresentation, opt => opt.MapFrom(src => src.promo))
            .ForMember(dest => dest.promoPrixRepresentation, opt => opt.MapFrom(src => src.promoPrix));



            CreateMap<VehiculeCommand, Vehicule>()
            .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.idCommand))
            .ForMember(dest => dest.photo, opt => opt.MapFrom(src => src.photoCommand))
            .ForMember(dest => dest.marque, opt => opt.MapFrom(src => src.marqueCommand))
            .ForMember(dest => dest.typeMoteur, opt => opt.MapFrom(src => src.typeMoteurCommand))
            .ForMember(dest => dest.prix, opt => opt.MapFrom(src => src.prixCommand))
            .ForMember(dest => dest.estDispo, opt => opt.MapFrom(src => src.estDispoCommand))
             .ForMember(dest => dest.promo, opt => opt.MapFrom(src => src.promoCommand))
            .ForMember(dest => dest.promoPrix, opt => opt.MapFrom(src => src.promoPrixCommand));



            CreateMap<Vehicule, VehiculeCommand>()
            .ForMember(dest => dest.idCommand, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.photoCommand, opt => opt.MapFrom(src => src.photo))
            .ForMember(dest => dest.marqueCommand, opt => opt.MapFrom(src => src.marque))
            .ForMember(dest => dest.typeMoteurCommand, opt => opt.MapFrom(src => src.typeMoteur))
            .ForMember(dest => dest.prixCommand, opt => opt.MapFrom(src => src.prix))
            .ForMember(dest => dest.estDispoCommand, opt => opt.MapFrom(src => src.estDispo))
            .ForMember(dest => dest.promoCommand, opt => opt.MapFrom(src => src.promo))
            .ForMember(dest => dest.promoPrixCommand, opt => opt.MapFrom(src => src.promoPrix));


        }
    }
}
