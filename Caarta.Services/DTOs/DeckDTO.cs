using Caarta.Data.Entities;
using Caarta.Services.DTOs.Abstractions;

namespace Caarta.Services.DTOs
{
    public class DeckDTO : BaseDTO
    {
        public string Name { get; set; }
        public string CreatorId { get; set; }
        public virtual AppUser? Creator { get; set; }
        public virtual ICollection<CardDTO>? Cards { get; set; }
        public byte? Type { get; set; }
        public virtual ICollection<UserSaveDeck>? SavedBy { get; set; }
        public int CategoryId { get; set; }
        public virtual CategoryDTO? Category { get; set; }
        public int LanguageId { get; set; }
        public virtual LanguageDTO? Language { get; set; }
    }
}
