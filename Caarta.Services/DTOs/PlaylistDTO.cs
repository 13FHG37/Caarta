using Caarta.Data.Entities;
using Caarta.Services.DTOs.Abstractions;

namespace Caarta.Services.DTOs
{
    public class PlaylistDTO : BaseDTO
    {
        public PlaylistDTO()
        {
            Type = 0;
        }
        public string Name { get; set; }
        public virtual AppUser? Creator { get; set; }
        public virtual HashSet<Deck>? Cards { get; set; }
        public byte? Type { get; set; }
    }
}
