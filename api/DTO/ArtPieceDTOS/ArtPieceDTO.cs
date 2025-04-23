using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.DTO.ArtPieceDTOS
{
    public class ArtPieceDTO
    {
        public string? Title { get; set; } = string.Empty;
        public string? Artist { get; set; } = string.Empty;
        public string? Meduim { get; set; } = string.Empty;
        public string? Classification { get; set; } = string.Empty;
        public string? Technique { get; set; } = string.Empty;
        public string? Dimensions { get; set; } = string.Empty;
        public string? Genre { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string? Location { get; set; } = string.Empty;
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public List<Reviews>? reviews { get; set; }
        
    }
}