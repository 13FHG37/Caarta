using AutoMapper;
using Caarta.Data.Entities;
using Caarta.Services.DTOs;

namespace Caarta.Services.Profiles
{
    public class DeckInCardlistProfile : Profile
    {
        public DeckInCardlistProfile()
        {
            CreateMap<DeckInCardlist, DeckInCardlistDTO>()
                    .ReverseMap();
        }
    }
}
