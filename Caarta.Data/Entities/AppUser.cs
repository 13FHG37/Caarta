using Microsoft.AspNetCore.Identity;

namespace Caarta.Data.Entities
{
    public class AppUser : IdentityUser
    {
        //user role, inheriting IdentityUser
        public AppUser()
        {
            Decks = new HashSet<Deck>();
            Playlists = new HashSet<Playlist>();
            ColorThemeId = 0;
        }

        public string? ProfilePictureUrl { get; set; }
        public virtual ICollection<Deck>? Decks { get; set; }
        public virtual ICollection<Playlist>? Playlists { get; set; }
        public int ColorThemeId { get; set; }
    }
}
