using Caarta.Data.Entities;

namespace Caarta.Models
{
    public class UserEditViewModel : AppUser
    {
        public IFormFile? ProfilePicture { get; set; }
    }
}
