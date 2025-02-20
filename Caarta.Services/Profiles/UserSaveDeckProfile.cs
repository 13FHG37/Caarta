using AutoMapper;
using Caarta.Data.Entities;
using Caarta.Services.DTOs;

namespace Caarta.Services.Profiles
{
    public class UserSaveDeckProfile : Profile
    {
        public UserSaveDeckProfile()
        {
            CreateMap<UserSaveDeck, UserSaveDeckDTO>()
                .ReverseMap();
        }
    }
}
