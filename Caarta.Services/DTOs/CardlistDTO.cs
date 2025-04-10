
using Caarta.Data.Entities;
using Caarta.Data.Entities.Abstractions;
using Caarta.Services.DTOs.Abstractions;

namespace Caarta.Services.DTOs
{
    public class CardlistDTO : BaseDTO
    {
        public string Name { get; set; }
        public string CreatorId { get; set; }
        public virtual AppUser? Creator { get; set; }
        public virtual ICollection<DeckInCardlistDTO>? Decks { get; set; }
        public int LanguageId { get; set; }
        public virtual LanguageDTO? Language { get; set; }
        public DateTime TimeOfCreation { get; set; }
        public bool IsPublic { get; set; }
    }
}
