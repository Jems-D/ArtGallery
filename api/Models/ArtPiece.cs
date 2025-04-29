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
        [Column("ObjectId")]
        public int? ObjectId{ get; set; } //unique identifier for every single object on the harvard museum api
        [Column("Title")]
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
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public string? Dated { get; set; } = string.Empty;
        [Column("Culture")]
        public string? Culture { get; set; } = string.Empty;
        [Column("Description")]
        public string? Description { get; set; } = string.Empty;
        public string? ImageUrl { get; set; } = string.Empty;
        public string? WebsiteUrl { get; set; } = string.Empty;
        public List<Reviews> reviews { get; set; } = new List<Reviews>();
        public List<Favourites> favourites { get; set; } = new List<Favourites>();

        
    }
}