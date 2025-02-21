using Caarta.Data.Entities;
using Caarta.Data.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Caarta.Data.Repositories
{
    public class UserSaveDeckRepository : IUserSaveDeckRepository
    {
        private ApplicationDbContext _context;
        public UserSaveDeckRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(UserSaveDeck userSaveDeck)
        {
            _context.UserSaveDeck.Add(userSaveDeck);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(UserSaveDeck userSaveDeck)
        {
            var existingEntity = _context.UserSaveDeck.Local
        .FirstOrDefault(usd => usd.AppUserId == userSaveDeck.AppUserId && usd.DeckId == userSaveDeck.DeckId);

            if (existingEntity == null)
            {
                existingEntity = await _context.UserSaveDeck
                    .FirstOrDefaultAsync(usd => usd.AppUserId == userSaveDeck.AppUserId && usd.DeckId == userSaveDeck.DeckId);
            }

            if (existingEntity != null)
            {
                Console.WriteLine($"Deleting: AppUserId={existingEntity.AppUserId}, DeckId={existingEntity.DeckId}");
                _context.UserSaveDeck.Remove(existingEntity);
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
