using AutoMapper;
using Caarta.Data.Entities;
using Caarta.Data.Repositories;
using Caarta.Data.Repositories.Abstractions;
using Caarta.Services.Abstractions;
using Caarta.Services.DTOs;

namespace Caarta.Services.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(CategoryDTO model)
        {
            var category = _mapper.Map<Category>(model);
            await _categoryRepository.AddAsync(category);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _categoryRepository.DeleteByIdAsync(id);
        }

        public async Task<CategoryDTO> GetByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task<ICollection<CategoryDTO>> GetAllAsync()
        {
            var categories = (await _categoryRepository.GetAllAsync())
                .ToList();
            return _mapper.Map<ICollection<CategoryDTO>>(categories);
        }

        public async Task UpdateAsync(CategoryDTO model)
        {
            var category = _mapper.Map<Category>(model);
            await _categoryRepository.UpdateAsync(category);
        }

        public ICollection<CategoryDTO> GetByName(string name)
        {
            var categories = _categoryRepository.GetAsync(category => category.Name == name);
            return _mapper.Map<ICollection<CategoryDTO>>(categories);
        }
    }
}
