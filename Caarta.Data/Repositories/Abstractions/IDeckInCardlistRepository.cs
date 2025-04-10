using Caarta.Data.Entities;

namespace Caarta.Data.Repositories.Abstractions
{
    public interface IDeckInCardlistRepository
    {
        Task CreateAsync(DeckInCardlist deckInCardlist);
        Task DeleteAsync(DeckInCardlist deckInCardlist);
    }
}