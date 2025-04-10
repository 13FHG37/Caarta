using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caarta.Data.Entities;
using Caarta.Data.Repositories.Abstractions;

namespace Caarta.Data.Repositories
{
    public class CardlistRepository : CrudRepository<Cardlist>, ICardlistRepository
    {
        private readonly ApplicationDbContext _context;

        public CardlistRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
