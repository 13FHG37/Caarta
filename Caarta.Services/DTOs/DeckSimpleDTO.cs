namespace Caarta.Services.DTOs
{
    public class DeckSimpleDTO : DeckDTO
    {
        public List<CardSimpleDTO> SimpleCards { get; set; } = new List<CardSimpleDTO>();
    }
}
