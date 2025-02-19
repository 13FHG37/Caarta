using AutoMapper;
using Caarta.Data.Entities;
using Caarta.Services.DTOs;

namespace Caarta.Services.Profiles
{
    public class LanguageProfile : Profile
    {
        public LanguageProfile() { 
            CreateMap<Language, LanguageDTO>()
                .ReverseMap();
        }
    }
}
