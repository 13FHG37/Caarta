using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caarta.Data.Entities;

namespace Caarta.Services.DTOs
{
    public class UserSaveDeckDTO
    {
        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
        public int DeckId { get; set; }
        public virtual Deck Deck { get; set; }
        public DateTime TimeOfSaving { get; set; }
    }
}
