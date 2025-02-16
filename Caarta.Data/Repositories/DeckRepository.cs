using Caarta.Data.Entities;
using Caarta.Data.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caarta.Data.Repositories
{
    public class DeckRepository : CrudRepository<Deck>, IDeckRepository
    {
        private readonly ApplicationDbContext _context;

        public DeckRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
