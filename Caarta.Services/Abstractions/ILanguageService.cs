using Caarta.Services.DTOs;

namespace Caarta.Services.Abstractions
{
    public interface ILanguageService
    {
        Task<ICollection<LanguageDTO>> GetAllAsync();
        Task<LanguageDTO> GetByIdAsync(int id);
        ICollection<LanguageDTO> GetByName(string name);
        Task CreateAsync(LanguageDTO language);
        Task DeleteByIdAsync(int id);
        Task UpdateAsync(LanguageDTO language);
    }
}
