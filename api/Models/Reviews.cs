using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using api.Entities;

namespace api.Models
{
    [Table("Reviews")]
    public class Reviews
    {
        [Column("Id")]
        [Key]
        public int Id { get; set; }
        [Column("Title")]
        public string? Title { get; set; } = string.Empty;
        [Column("Content")]
        public string? Content { get; set; } = string.Empty;
        [Column("Rating", TypeName ="decimal(18,2)")]
        public  decimal Rating { get; set; }
        [Column("CreatedAt")]
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        [Column("ArtPieceId")]
        public int ArtPieceId { get; set; }
        public ArtPiece? ArtPiece { get; set; } // for navigation only
        public Guid UserId { get; set; }
        public User? user { get; set; }

    }
}