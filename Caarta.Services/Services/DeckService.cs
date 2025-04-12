using AutoMapper;
using Caarta.Data.Entities;
using Caarta.Data.Repositories.Abstractions;
using Caarta.Services.Abstractions;
using Caarta.Services.DTOs;


namespace Caarta.Services.Services
{
    public class DeckService : IDeckService
    {
        private readonly IDeckRepository _deckRepository;
        private readonly IDeckInCardlistRepository _deckInCardlistRepository;
        private readonly IUserSaveDeckRepository _userSaveDeckRepository;
        private readonly IMapper _mapper;
        public DeckService(IDeckRepository deckRepository, IDeckInCardlistRepository deckInCardlistRepository, IMapper mapper, IUserSaveDeckRepository userSaveDeckRepository)
        {
            _deckRepository = deckRepository;
            _deckInCardlistRepository = deckInCardlistRepository;
            _mapper = mapper;
            _userSaveDeckRepository = userSaveDeckRepository;
        }

        public async Task CreateAsync(DeckDTO model)
        {
            var deck = _mapper.Map<Deck>(model);

            await _deckRepository.AddAsync(deck);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _deckRepository.DeleteByIdAsync(id);
        }

        public async Task<DeckDTO> GetByIdAsync(int id)
        {
            var deck = await _deckRepository.GetByIdAsync(id);
            return _mapper.Map<DeckDTO>(deck);
        }

        public async Task<ICollection<DeckDTO>> GetAllAsync()
        {
            var decks = (await _deckRepository.GetAllAsync())
                .ToList();
            return _mapper.Map<ICollection<DeckDTO>>(decks);
        }

        public async Task UpdateAsync(DeckDTO model)
        {
            var deck = _mapper.Map<Deck>(model);
            await _deckRepository.UpdateAsync(deck);
        }

        public ICollection<DeckDTO> GetByName(string name)
        {
            var decks = _deckRepository.GetAsync(deck => deck.Name == name);
            return _mapper.Map<ICollection<DeckDTO>>(decks);
        }

        public async Task AddUserSaveDeckAsync(UserSaveDeckDTO userSaveDeckDTO)
        {
            var save = _mapper.Map<UserSaveDeck>(userSaveDeckDTO);
            await _userSaveDeckRepository.CreateAsync(save);
        }
        public async Task DeleteUserSaveDeckAsync(UserSaveDeckDTO userSaveDeckDTO)
        {
            var save = _mapper.Map<UserSaveDeck>(userSaveDeckDTO);
            await _userSaveDeckRepository.DeleteAsync(save);
        }

        public async Task AddToCardlist(DeckInCardlistDTO deckInCardlistDTO)
        {
            await _deckInCardlistRepository.CreateAsync(new DeckInCardlist
            {
                DeckId = deckInCardlistDTO.DeckId,
                CardlistId = deckInCardlistDTO.CardlistId
            });
        }

        public async Task RemoveFromCardlist(DeckInCardlistDTO deckInCardlistDTO)
        {
            var dfc = _mapper.Map<DeckInCardlist>(deckInCardlistDTO);
            await _deckInCardlistRepository.DeleteAsync(dfc);
        }
    }
}