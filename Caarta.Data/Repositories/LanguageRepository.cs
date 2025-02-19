using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caarta.Data.Entities;
using Caarta.Data.Repositories.Abstractions;

namespace Caarta.Data.Repositories
{
    public class LanguageRepository : CrudRepository<Language>, ILanguageRepository
    {
        private readonly ApplicationDbContext _context;
        public LanguageRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
