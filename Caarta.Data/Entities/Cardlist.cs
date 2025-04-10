using Caarta.Data.Entities.Abstractions;

namespace Caarta.Data.Entities
{
    public class Cardlist : BaseEntity
    {
        public Cardlist()
        {
            IsPublic = false;
        }

        public string Name { get; set; }
        public string CreatorId { get; set; }
        public virtual AppUser? Creator { get; set; }
        public virtual ICollection<DeckInCardlist>? Decks { get; set; }
        public int LanguageId { get; set; }
        public virtual Language? Language { get; set; }
        public DateTime TimeOfCreation { get; set; }
        public bool IsPublic { get; set; }
    }
}
