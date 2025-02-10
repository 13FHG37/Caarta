using Caarta.Data.Entities.Abstractions;

namespace Caarta.Data.Entities
{
    public class Deck : BaseEntity
    {
        public Deck()
        {
            Cards = new HashSet<Card>();
            Type = 0;
        }
        public string Name { get; set; }

        public string CreatorId { get; set; }
        public virtual AppUser? Creator { get; set; }
        public virtual ICollection<Card>? Cards { get; set; }
        public byte? Type { get; set; }
    }
}
