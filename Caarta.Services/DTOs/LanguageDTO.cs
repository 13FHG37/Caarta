using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caarta.Data.Entities;
using Caarta.Services.DTOs.Abstractions;

namespace Caarta.Services.DTOs
{
    public class LanguageDTO : BaseDTO
    {
        public string Name { get; set; }
        public virtual ICollection<DeckDTO>? Decks { get; set; }
    }
}
