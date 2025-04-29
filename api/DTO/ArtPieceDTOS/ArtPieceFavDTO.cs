using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTO.ArtPieceDTOS
{
    public class ArtPieceFavDTO
    {
        public string? Title { get; set; }
        public string? imageUrl { get; set; }
        public DateTime AddedAt { get; set; }
    }
}