using AutoMapper;
using Caarta.Data.Entities;
using Caarta.Data.Repositories.Abstractions;
using Caarta.Services.Abstractions;
using Caarta.Services.DTOs;


namespace Caarta.Services.Services
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;
        private readonly IMapper _mapper;
        public CardService(ICardRepository cardRepository, IMapper mapper)
        {
            _cardRepository = cardRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(CardDTO model)
        {
            var Card = _mapper.Map<Card>(model);

            await _cardRepository.AddAsync(Card);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _cardRepository.DeleteByIdAsync(id);
        }

        public async Task<CardDTO> GetByIdAsync(int id)
        {
            var card = await _cardRepository.GetByIdAsync(id);
            return _mapper.Map<CardDTO>(card);
        }

        public async Task<ICollection<CardDTO>> GetAllAsync()
        {
            var cards = (await _cardRepository.GetAllAsync())
                .ToList();
            return _mapper.Map<List<CardDTO>>(cards);
        }

        public async Task UpdateAsync(CardDTO model)
        {
            var card = _mapper.Map<Card>(model);
            await _cardRepository.UpdateAsync(card);
        }
    }
}
