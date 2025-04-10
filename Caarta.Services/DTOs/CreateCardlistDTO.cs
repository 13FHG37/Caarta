using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Caarta.Services.DTOs
{
    public class CreateCardlistDTO : CardlistDTO
    {
        public List<SelectListItem>? Languages { get; set; }
    }
}
