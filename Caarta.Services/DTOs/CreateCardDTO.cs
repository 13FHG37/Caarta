using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Caarta.Services.DTOs
{
    public class CreateCardDTO : CardDTO
    {
        public IFormFile? FrontPicture { get; set; }
        public IFormFile? BackPicture { get; set; }
        public string CreatorId { get; set; }
    }
}
