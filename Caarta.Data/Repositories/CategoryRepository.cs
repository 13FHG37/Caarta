using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caarta.Data.Entities;
using Caarta.Data.Repositories.Abstractions;

namespace Caarta.Data.Repositories
{
    public class CategoryRepository : CrudRepository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
