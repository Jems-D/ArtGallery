using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.ArtPieceDTOS;
using api.Models;

namespace api.Mappers
{
    public static class ArtPieceMappers
    {
        public static ArtPieceDTO ToArtPieceDTO(this ArtPiece artPiece){
            return new ArtPieceDTO{
                Title = artPiece.Title,
                Artist = artPiece.Artist,
                Meduim = artPiece.Meduim,
                Classification = artPiece.Classification,
                Technique = artPiece.Classification,
                Dimensions = artPiece.Dimensions,
                Genre = artPiece.Genre,
                Description = artPiece.Description,
                Location = artPiece.Location,
                CreatedAt = artPiece.DateCreated,
                reviews = artPiece.reviews.Select(s => s.ToReviewDTO()).ToList()
            };
        }

        public static ArtPiece? ToArtPiece(this CreateArtPieceDTO artPieceDTO){
            return new ArtPiece{
                Title = artPieceDTO.Title,
                Artist = artPieceDTO.Artist,
                Meduim = artPieceDTO.Meduim,
                Classification = artPieceDTO.Classification,
                Technique = artPieceDTO.Technique,
                Dimensions = artPieceDTO.Dimensions,
                Genre = artPieceDTO.Genre,
                Description = artPieceDTO.Description,
                Location = artPieceDTO.Location,
            };
        }
    }
}