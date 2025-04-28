using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTO.ReviewDTOS
{
    public class ReviewDTO
    {
        public string? Title { get; set; } = string.Empty;
        public string? Content { get; set; } = string.Empty;
        public  decimal Rating { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public string? CreatedBy { get; set; }
        public int ArtPieceId { get; set; }

    }
}