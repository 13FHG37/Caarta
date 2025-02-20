using Caarta.Data.Entities;
using Caarta.Data.Repositories.Abstractions;

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
    }
}
