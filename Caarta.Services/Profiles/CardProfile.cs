using AutoMapper;
using Caarta.Data.Entities;
using Caarta.Services.DTOs;

namespace Caarta.Services.Profiles
{
    public class CardProfile : Profile
    {
        public CardProfile()
        {
            CreateMap<Card, CardDTO>()
                .ReverseMap();
        }
    }
}
