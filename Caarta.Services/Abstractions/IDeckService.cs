using Caarta.Services.DTOs;


namespace Caarta.Services.Abstractions
{
    public interface IDeckService
    {
        Task<List<DeckDTO>> GetDecksAsync();
        Task<DeckDTO> GetDeckByIdAsync(int id);
        Task AddDeckAsync(DeckDTO card);
        Task DeleteDeckByIdAsync(int id);
        Task UpdateDeckAsync(DeckDTO deck);
    }
}
