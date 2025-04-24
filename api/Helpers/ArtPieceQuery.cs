using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Helpers
{
    public class ArtPieceQuery
    {
        public string? sortBy { get; set; } = "Action";
        public bool? isDescending { get; set; } = false;


    }
}