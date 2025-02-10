using AutoMapper;
using Caarta.Data.Entities;
using Caarta.Services.DTOs;

namespace Caarta.Services.Profiles
{
    public class PlaylistProfile : Profile
    {
        public PlaylistProfile()
        {
            CreateMap<Playlist, PlaylistDTO>()
                .ReverseMap();
        }
    }
}
