namespace Caarta.Services.DTOs
{
    public class CardlistSimpleDTO : CardlistDTO
    {
        public List<CardSimpleDTO> SimpleCards { get; set; } = new List<CardSimpleDTO>();
    }
}
