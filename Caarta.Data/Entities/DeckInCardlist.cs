
namespace Caarta.Data.Entities
{
    public class DeckInCardlist
    {
        public int DeckId { get; set; }
        public virtual Deck? Deck { get; set; }
        public int CardlistId { get; set; }
        public virtual Cardlist? Cardlist { get; set; }
    }
}
