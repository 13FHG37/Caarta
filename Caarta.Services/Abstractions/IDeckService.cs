using Caarta.Services.DTOs;


namespace Caarta.Services.Abstractions
{
    public interface IDeckService
    {
        Task<ICollection<DeckDTO>> GetAllAsync();
        Task<DeckDTO> GetByIdAsync(int id);
        ICollection<DeckDTO> GetByName(string name);
        Task CreateAsync(DeckDTO deck);
        Task DeleteByIdAsync(int id);
        Task UpdateAsync(DeckDTO deck);
        Task AddUserSaveDeckAsync(UserSaveDeckDTO userSaveDeckDTO);
        Task DeleteUserSaveDeckAsync(UserSaveDeckDTO userSaveDeckDTO);
        Task AddToCardlist(DeckInCardlistDTO deckInCardlistDTO);
    }
}