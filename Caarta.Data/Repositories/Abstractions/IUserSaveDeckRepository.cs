using Caarta.Data.Entities;

namespace Caarta.Data.Repositories.Abstractions
{
    public interface IUserSaveDeckRepository
    {
        Task CreateAsync(UserSaveDeck userSaveDeck);
        Task DeleteAsync(UserSaveDeck userSaveDeck);
    }
}
