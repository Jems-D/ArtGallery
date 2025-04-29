using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using api.Entities;

namespace api.Models
{
    [Table("FavouritesList")]
    public class Favourites
    {
        [Column("UserId")]
        public Guid UserId { get; set; }
        [Column("ArtPieceId")]
        public int ArtPieceId { get; set; }
        public User? User { get; set; }
        public ArtPiece ArtPiece { get; set; }

    }
}