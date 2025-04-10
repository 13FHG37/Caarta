using Caarta.Data.Entities;
using Caarta.Data.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Caarta.Data.Repositories
{
    public class DeckInCardlistRepository : IDeckInCardlistRepository
    {
        private ApplicationDbContext _context;
        public DeckInCardlistRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(DeckInCardlist DeckInCardlist)
        {
            _context.DeckInCardlist.Add(DeckInCardlist);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(DeckInCardlist DeckInCardlist)
        {
            var existingEntity = _context.DeckInCardlist.Local
        .FirstOrDefault(dic => dic.DeckId == DeckInCardlist.DeckId && dic.CardlistId == DeckInCardlist.CardlistId);

            if (existingEntity == null)
            {
                existingEntity = await _context.DeckInCardlist
                    .FirstOrDefaultAsync(dic => dic.DeckId == DeckInCardlist.DeckId && dic.CardlistId == DeckInCardlist.CardlistId);
            }

            if (existingEntity != null)
            {
                Console.WriteLine($"Deleting: DeckId={existingEntity.DeckId}, CardlistId={existingEntity.CardlistId}");
                _context.DeckInCardlist.Remove(existingEntity);
                await _context.SaveChangesAsync();
                Console.WriteLine("Deleted successfully.");
            }
            else
            {
                Console.WriteLine("Entity not found.");
            }
        }
    }
}
