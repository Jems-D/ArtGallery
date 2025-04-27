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
        public string? property {get; set; }

    }

    public class PropSearchQuery
    {
        public int pageNumber { get; set; } = 1;
        public string? property { get; set; } = string.Empty;
    }

    public class KeywordSearchQuery
    {
        public int pageNumber { get; set; } = 1;
        public string?  keyword { get; set; }

    }
    public class GetOtherArtworksQuery
    {
        public int personId { get; set; }
        public int objectId { get; set; }
    }
}