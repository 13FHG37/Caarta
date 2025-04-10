using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caarta.Services.DTOs
{
    public class CardSimpleDTO
    {
        public string? FrontText { get; set; }
        public string? FrontPictureUrl { get; set; }
        public string? BackText { get; set; }
        public string? BackPictureUrl { get; set; }
        public byte? CardType { get; set; }
    }
}
