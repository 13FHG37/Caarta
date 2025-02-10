using AutoMapper;
using Caarta.Data.Entities;
using Caarta.Data.Repositories.Abstractions;
using Caarta.Services.Abstractions;
using Caarta.Services.DTOs;


namespace Caarta.Services.Services
{
    public class DeckService : IDeckService
    {
        private readonly ICrudRepository<Deck> _DeckRepository;
        private readonly IMapper _mapper;
        public DeckService(ICrudRepository<Deck> DeckRepository, IMapper mapper)
        {
            _DeckRepository = DeckRepository;
            _mapper = mapper;
        }

        public async Task AddDeckAsync(DeckDTO model)
        {
            var Deck = _mapper
                .Map<Deck>(model);

            await _DeckRepository.AddAsync(Deck);
        }

        public async Task DeleteDeckByIdAsync(int id)
        {
            await _DeckRepository.DeleteByIdAsync(id);
        }

        public async Task<DeckDTO> GetDeckByIdAsync(int id)
        {
            var Deck = await _DeckRepository.GetByIdAsync(id);
            return _mapper.Map<DeckDTO>(Deck);
        }

        public async Task<List<DeckDTO>> GetDecksAsync()
        {
            var Decks = (await _DeckRepository.GetAllAsync())
                .ToList();
            return _mapper.Map<List<DeckDTO>>(Decks);
        }

        public async Task UpdateDeckAsync(DeckDTO model)
        {
            var Deck = _mapper.Map<Deck>(model);
            await _DeckRepository.UpdateAsync(Deck);
        }
    }
}
