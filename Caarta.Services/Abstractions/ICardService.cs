using Caarta.Data.Entities;
using Caarta.Services.DTOs;


namespace Caarta.Services.Abstractions
{
    public interface ICardService
    {
        Task<ICollection<CardDTO>> GetAllAsync();
        Task<CardDTO> GetByIdAsync(int id);
        Task CreateAsync(CardDTO card);
        Task DeleteByIdAsync(int id);
        Task UpdateAsync(CardDTO card);
    }
}
