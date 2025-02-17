using Caarta.Data.Entities.Abstractions;

namespace Caarta.Data.Entities
{
    public class Card : BaseEntity
    {
        public int DeckId { get; set; }
        public virtual Deck? Deck { get; set; }
        public string? FrontText { get; set; }
        public string? FrontPictureUrl { get; set; }
        public string? BackText { get; set; }
        public string? BackPictureUrl { get; set; }
    }
}