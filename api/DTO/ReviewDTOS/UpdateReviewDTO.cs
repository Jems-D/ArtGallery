using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTO.ReviewDTOS
{
    public class UpdateReviewDTO
    {
        public string? Title { get; set; } = string.Empty;
        public string? Content { get; set; } = string.Empty;
        public  decimal Rating { get; set; } 
    }
}