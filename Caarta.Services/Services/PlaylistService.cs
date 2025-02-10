using AutoMapper;
using Caarta.Data.Entities;
using Caarta.Data.Repositories.Abstractions;
using Caarta.Services.Abstractions;
using Caarta.Services.DTOs;


namespace Caarta.Services.Services
{
    public class PlaylistService : IPlaylistService
    {
        private readonly ICrudRepository<Playlist> _PlaylistRepository;
        private readonly IMapper _mapper;
        public PlaylistService(ICrudRepository<Playlist> PlaylistRepository, IMapper mapper)
        {
            _PlaylistRepository = PlaylistRepository;
            _mapper = mapper;
        }

        public async Task AddPlaylistAsync(PlaylistDTO model)
        {
            var Playlist = _mapper
                .Map<Playlist>(model);

            await _PlaylistRepository.AddAsync(Playlist);
        }

        public async Task DeletePlaylistByIdAsync(int id)
        {
            await _PlaylistRepository.DeleteByIdAsync(id);
        }

        public async Task<PlaylistDTO> GetPlaylistByIdAsync(int id)
        {
            var Playlist = await _PlaylistRepository.GetByIdAsync(id);
            return _mapper.Map<PlaylistDTO>(Playlist);
        }

        public async Task<List<PlaylistDTO>> GetPlaylistsAsync()
        {
            var Playlists = (await _PlaylistRepository.GetAllAsync())
                .ToList();
            return _mapper.Map<List<PlaylistDTO>>(Playlists);
        }

        public async Task UpdatePlaylistAsync(PlaylistDTO model)
        {
            var Playlist = _mapper.Map<Playlist>(model);
            await _PlaylistRepository.UpdateAsync(Playlist);
        }
    }
}
