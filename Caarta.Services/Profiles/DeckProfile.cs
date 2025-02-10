using AutoMapper;
using Caarta.Data.Entities;
using Caarta.Services.DTOs;

namespace Caarta.Services.Profiles
{
    public class DeckProfile : Profile
    {
        public DeckProfile()
        {
            CreateMap<Deck, DeckDTO>()
                .ReverseMap();
        }
    }
}
