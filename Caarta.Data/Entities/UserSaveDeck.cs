using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caarta.Data.Entities
{
    public class UserSaveDeck
    {
        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
        public int DeckId { get; set; }
        public virtual Deck Deck { get; set; }
        public DateTime TimeOfSaving { get; set; }
    }
}
