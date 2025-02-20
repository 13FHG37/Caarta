using Caarta.Data.Entities.Abstractions;

namespace Caarta.Data.Entities
{
    public class Deck : BaseEntity
    {
        public Deck()
        {
            Cards = new HashSet<Card>();
            IsPublic = false;
        }

        public string Name { get; set; }

        public string CreatorId { get; set; }
        public virtual AppUser? Creator { get; set; }
        public virtual ICollection<Card>? Cards { get; set; }
        public virtual ICollection<UserSaveDeck>? SavedBy { get; set; }
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        public int LanguageId { get; set; }
        public virtual Language? Language { get; set; }
        public DateTime TimeOfCreation { get; set; }
        public bool IsPublic { get; set; }
    }
}
