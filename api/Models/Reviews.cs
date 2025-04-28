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
        //To add ObjectId
        [Column("Id")]
        [Key]
        public int Id { get; set; }
        [Column("Title")]
        public string? Title { get; set; } = string.Empty;
        public int ObjectId { get; set; }
        [Column("Content")]
        public string? Content { get; set; } = string.Empty;
        [Column("Rating", TypeName ="decimal(18,2)")]
        public  decimal Rating { get; set; }
        [Column("CreatedAt")]
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        [Column("ArtPieceId")]
        public int ArtPieceId { get; set; }
        public string? CreatedBy { get; set; }
        public ArtPiece? ArtPiece { get; set; } // for navigation only
        public Guid UserId { get; set; }
        public User? User { get; set; }

    }
}