using AutoMapper;
using Caarta.Data.Entities;
using Caarta.Data.Repositories;
using Caarta.Data.Repositories.Abstractions;
using Caarta.Services.Abstractions;
using Caarta.Services.DTOs;

namespace Caarta.Services.Services
{
    public class LanguageService : ILanguageService
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;
        public LanguageService(ILanguageRepository languageRepository, IMapper mapper)
        {
            _languageRepository = languageRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(LanguageDTO model)
        {
            var language = _mapper.Map<Language>(model);

            await _languageRepository.AddAsync(language);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _languageRepository.DeleteByIdAsync(id);
        }

        public async Task<LanguageDTO> GetByIdAsync(int id)
        {
            var language = await _languageRepository.GetByIdAsync(id);
            return _mapper.Map<LanguageDTO>(language);
        }

        public async Task<ICollection<LanguageDTO>> GetAllAsync()
        {
            var languages = (await _languageRepository.GetAllAsync())
                .ToList();
            return _mapper.Map<ICollection<LanguageDTO>>(languages);
        }

        public async Task UpdateAsync(LanguageDTO model)
        {
            var language = _mapper.Map<Language>(model);
            await _languageRepository.UpdateAsync(language);
        }

        public ICollection<LanguageDTO> GetByName(string name)
        {
            var languages = _languageRepository.GetAsync(language => language.Name == name);
            return _mapper.Map<ICollection<LanguageDTO>>(languages);
        }
    }
}
