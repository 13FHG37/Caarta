using Caarta.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caarta.Services.Abstractions
{
    public interface IPlaylistService
    {
        Task<List<PlaylistDTO>> GetPlaylistsAsync();
        Task<PlaylistDTO> GetPlaylistByIdAsync(int id);
        Task AddPlaylistAsync(PlaylistDTO playlist);
        Task DeletePlaylistByIdAsync(int id);
        Task UpdatePlaylistAsync(PlaylistDTO playlist);
    }
}
