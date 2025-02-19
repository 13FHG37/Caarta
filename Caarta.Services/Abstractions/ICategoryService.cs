using Caarta.Services.DTOs;

namespace Caarta.Services.Abstractions
{
    public interface ICategoryService
    {
        Task<ICollection<CategoryDTO>> GetAllAsync();
        Task<CategoryDTO> GetByIdAsync(int id);
        ICollection<CategoryDTO> GetByName(string name);
        Task CreateAsync(CategoryDTO category);
        Task DeleteByIdAsync(int id);
        Task UpdateAsync(CategoryDTO category);
    }
}
