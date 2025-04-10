using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caarta.Services.DTOs;

namespace Caarta.Services.Abstractions
{
    public interface ICardlistService
    {
        Task<ICollection<CardlistDTO>> GetAllAsync();
        Task<CardlistDTO> GetByIdAsync(int id);
        ICollection<CardlistDTO> GetByName(string name);
        Task CreateAsync(CardlistDTO deck);
        Task DeleteByIdAsync(int id);
        Task UpdateAsync(CardlistDTO deck);
    }
}
