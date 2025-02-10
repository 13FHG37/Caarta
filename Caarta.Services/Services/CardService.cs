using AutoMapper;
using Caarta.Data.Entities;
using Caarta.Data.Repositories.Abstractions;
using Caarta.Services.Abstractions;
using Caarta.Services.DTOs;


namespace Caarta.Services.Services
{
    public class CardService : ICardService
    {
        private readonly ICrudRepository<Card> _CardRepository;
        private readonly IMapper _mapper;
        public CardService(ICrudRepository<Card> CardRepository, IMapper mapper)
        {
            _CardRepository = CardRepository;
            _mapper = mapper;
        }

        public async Task AddCardAsync(CardDTO model)
        {
            var Card = _mapper
                .Map<Card>(model);

            await _CardRepository.AddAsync(Card);
        }

        public async Task DeleteCardByIdAsync(int id)
        {
            await _CardRepository.DeleteByIdAsync(id);
        }

        public async Task<CardDTO> GetCardByIdAsync(int id)
        {
            var Card = await _CardRepository.GetByIdAsync(id);
            return _mapper.Map<CardDTO>(Card);
        }

        public async Task<List<CardDTO>> GetCardsAsync()
        {
            var Cards = (await _CardRepository.GetAllAsync())
                .ToList();
            return _mapper.Map<List<CardDTO>>(Cards);
        }

        public async Task UpdateCardAsync(CardDTO model)
        {
            var Card = _mapper.Map<Card>(model);
            await _CardRepository.UpdateAsync(Card);
        }
    }
}
