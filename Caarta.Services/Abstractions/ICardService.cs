using Caarta.Services.DTOs;


namespace Caarta.Services.Abstractions
{
    public interface ICardService
    {
        Task<List<CardDTO>> GetCardsAsync();
        Task<CardDTO> GetCardByIdAsync(int id);
        Task AddCardAsync(CardDTO card);
        Task DeleteCardByIdAsync(int id);
        Task UpdateCardAsync(CardDTO card);
    }
}
