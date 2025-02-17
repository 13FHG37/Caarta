using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caarta.Data.Entities.Abstractions;

namespace Caarta.Data.Entities
{
    public class Category: BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Deck> Decks { get; set; }
    }
}
