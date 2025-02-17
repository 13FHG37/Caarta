using Caarta.Data.Entities;
using Caarta.Services.DTOs.Abstractions;

namespace Caarta.Services.DTOs
{
    public class CardDTO : BaseDTO
    {
        public int DeckId { get; set; }
        public virtual DeckDTO? Deck { get; set; }
        public string? FrontText { get; set; }
        public string? FrontPictureUrl { get; set; }
        public string? BackText { get; set; }
        public string? BackPictureUrl { get; set; }
    }
}
