using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Caarta.Services.DTOs
{
    public class CreateDeckDTO : DeckDTO
    {
        public List<SelectListItem>? Categories { get; set; }
        public List<SelectListItem>? Languages { get; set; }
        public List<CreateCardDTO> CreateCards { get; set; } = new List<CreateCardDTO>();
    }
}
