using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Caarta.Data.Entities;
using Caarta.Data.Repositories.Abstractions;
using Caarta.Services.Abstractions;
using Caarta.Services.DTOs;

namespace Caarta.Services.Services
{
    public class CardlistService : ICardlistService
    {
        private readonly ICardlistRepository _cardlistRepository;
        private readonly IMapper _mapper;
        public CardlistService(ICardlistRepository cardlistRepository, IMapper mapper)
        {
            _cardlistRepository = cardlistRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(CardlistDTO model)
        {
            var cardlist = _mapper.Map<Cardlist>(model);

            await _cardlistRepository.AddAsync(cardlist);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _cardlistRepository.DeleteByIdAsync(id);
        }

        public async Task<CardlistDTO> GetByIdAsync(int id)
        {
            var cardlist = await _cardlistRepository.GetByIdAsync(id);
            return _mapper.Map<CardlistDTO>(cardlist);
        }

        public async Task<ICollection<CardlistDTO>> GetAllAsync()
        {
            var cardlists = (await _cardlistRepository.GetAllAsync())
                .ToList();
            return _mapper.Map<ICollection<CardlistDTO>>(cardlists);
        }

        public async Task UpdateAsync(CardlistDTO model)
        {
            var cardlist = _mapper.Map<Cardlist>(model);
            await _cardlistRepository.UpdateAsync(cardlist);
        }

        public ICollection<CardlistDTO> GetByName(string name)
        {
            var cardlists = _cardlistRepository.GetAsync(cardlist => cardlist.Name == name);
            return _mapper.Map<ICollection<CardlistDTO>>(cardlists);
        }
    }
}
