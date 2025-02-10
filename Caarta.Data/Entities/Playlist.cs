using Caarta.Data.Entities.Abstractions;

namespace Caarta.Data.Entities
{
    public class Playlist : BaseEntity
    {
        public Playlist()
        {
            Decks = new HashSet<Deck>();
            Type = 0;
        }
        public string Name { get; set; }
        public virtual AppUser? Creator { get; set; }
        public virtual ICollection<Deck>? Decks { get; set; }
        public byte? Type { get; set; }
    }
}
