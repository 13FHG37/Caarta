
using AutoMapper;
using Caarta.Data.Entities;
using Caarta.Services.DTOs;

namespace Caarta.Services.Profiles
{
    public class CardlistProfile : Profile
    {
        public CardlistProfile()
        {
            CreateMap<Cardlist, CardlistDTO>()
                .ReverseMap();
        }
    }
}
