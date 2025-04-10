using Microsoft.AspNetCore.Identity;

namespace Caarta.Data.Entities
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            Created = new HashSet<Deck>();
            ColorThemeId = 0;
            ProfilePictureUrl = "user.png";
        }

        public string? ProfilePictureUrl { get; set; }
        public int ColorThemeId { get; set; }
        public virtual ICollection<Deck>? Created { get; set; }
        public virtual ICollection<Cardlist>? CreatedCardlists { get; set; }
        public virtual ICollection<UserSaveDeck>? Saved { get; set; }
    }
}
