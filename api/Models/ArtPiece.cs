using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("ArtPiece")]
    public class ArtPiece
    {
        [Column("Id")]
        [Key]
        public int Id { get; set; }
        [Column("Title")]
        public int? ObjectId{ get; set; } //unique identifier for every single object on the harvard museum api
        public string? Title { get; set; } = string.Empty;
        [Column("Meduim")]
        public string? Meduim { get; set; } = string.Empty;
        [Column("Classification")]
        public string? Classification { get; set; } = string.Empty;
        [Column("Technique")]
        public string? Technique { get; set; } = string.Empty;
        [Column("Dimensions")]
        public string? Dimensions { get; set; } = string.Empty;
        [Column("DateCreated")] 
        public DateTime? DateCreated { get; set; } = DateTime.Now;
        public string? Dated { get; set; } = string.Empty;
        [Column("Genre")]
        public string? Genre { get; set; } = string.Empty;
        [Column("Description")]
        public string? Description { get; set; } = string.Empty;
        [Column("Location")]
        public string? Location { get; set; } = string.Empty;
        public string? imageUrl { get; set; } = string.Empty;
        public string? websiteUrl { get; set; } = string.Empty;
        public string? placeOfOrigin { get; set; } = string.Empty;
        public List<Reviews> reviews { get; set; } = new List<Reviews>();

        
    }
}