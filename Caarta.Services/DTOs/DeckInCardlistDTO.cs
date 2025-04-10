using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caarta.Data.Entities;

namespace Caarta.Services.DTOs
{
    public class DeckInCardlistDTO
    {
        public int DeckId { get; set; }
        public virtual DeckDTO? Deck { get; set; }
        public int CardlistId { get; set; }
        public virtual CardlistDTO? Cardlist { get; set; }
    }
}
