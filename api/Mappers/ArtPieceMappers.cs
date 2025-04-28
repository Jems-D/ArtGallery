using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.ArtPieceDTOS;
using api.DTO.HarvardMusemApiDTOS;
using api.Models;

namespace api.Mappers
{
    public static class ArtPieceMappers
    {
        public static ArtPieceDTO ToArtPieceDTO(this ArtPiece artPiece){
            return new ArtPieceDTO{
                Title = artPiece.Title,
                Meduim = artPiece.Meduim,
                Classification = artPiece.Classification,
                Technique = artPiece.Classification,
                Dimensions = artPiece.Dimensions,
                Culture = artPiece.Culture,
                Description = artPiece.Description,
                CreatedAt = artPiece.DateCreated,
                reviews = artPiece.reviews.Select(s => s.ToReviewDTO()).ToList()
            };
        }

        public static ArtPiece? ToArtPiece(this CreateArtPieceDTO artPieceDTO){
            return new ArtPiece{
                Title = artPieceDTO.Title,
                Meduim = artPieceDTO.Meduim,
                Classification = artPieceDTO.Classification,
                Technique = artPieceDTO.Technique,
                Dimensions = artPieceDTO.Dimensions,
                Culture = artPieceDTO.Culture,
                Description = artPieceDTO.Description,
            };
        }

        public static ArtPiece? ToArtPieceFromMetadata(this ObjectMetadataDTO.Record record){
            string? imageUrl = record.ImagePermissionLevel < 2 ? record.PrimaryImageUrl : "";
            return new ArtPiece{
    
                Title = record.Title,
                ObjectId = record.ObjectId,
                Meduim = record.Medium,
                Classification = record.Classification,
                Technique = record.Technique,
                Dimensions = record.Dimensions,
                Culture = record.Culture,
                Description = record.Description,
                ImageUrl = imageUrl,
                WebsiteUrl = record.Url
            };
        }
    }
}