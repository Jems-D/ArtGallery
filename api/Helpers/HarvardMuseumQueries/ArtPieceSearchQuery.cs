using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Helpers.HarvardMuseumQueries
{
    public class ArtPieceSearchQuery
    {
        public int Id { get; set; }
        public int pageNumber { get; set; } = 1;
    }
}