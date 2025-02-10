using Caarta.Data.Entities;
using Caarta.Services.DTOs.Abstractions;

namespace Caarta.Services.DTOs
{
    public class DeckDTO : BaseDTO
    {
        public DeckDTO()
        {
            Type = 0;
        }
        public string Name { get; set; }
        public virtual AppUser? Creator { get; set; }
        public virtual HashSet<Card>? Cards { get; set; }
        public byte? Type { get; set; }
    }
}
