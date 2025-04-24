using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTO.ArtPieceDTOS
{
    public class UpdateArtPieceDTO
    {
        [Required]
        [MaxLength(200, ErrorMessage ="Title too long")]
        public string? Title { get; set; } = string.Empty;
        public string? Artist { get; set; } = string.Empty;
        public string? Meduim { get; set; } = string.Empty;
        public string? Classification { get; set; } = string.Empty;
        public string? Technique { get; set; } = string.Empty;
        public string? Dimensions { get; set; } = string.Empty;
        public string? Genre { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string? Location { get; set; } = string.Empty;
    }
}