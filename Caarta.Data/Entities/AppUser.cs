using Microsoft.AspNetCore.Identity;

namespace Caarta.Data.Entities
{
    public class AppUser : IdentityUser
    {
        //user role, inheriting IdentityUser
        public AppUser()
        {
            Created = new HashSet<Deck>();
            ColorThemeId = 0;
        }

        public string? ProfilePictureUrl { get; set; }
        public int ColorThemeId { get; set; }
        public virtual ICollection<Deck> Created { get; set; }
        public virtual ICollection<UserSaveDeck> Saved { get; set; }
    }
}
