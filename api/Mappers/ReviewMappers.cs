using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.ArtPieceDTOS;
using api.DTO.ReviewDTOS;
using api.Models;

namespace api.Mappers
{
    public static class ReviewMappers
    {
        public static Reviews ToReview(this CreateReviewDTO reviewDTO, int artPieceId){
            return new Reviews{
                Title = reviewDTO.Title,
                Content = reviewDTO.Content,
                Rating = reviewDTO.Rating,
                ArtPieceId = artPieceId
            };
        }

        public static ReviewDTO ToReviewDTO(this Reviews reviews){
            return new ReviewDTO{
                Title = reviews.Title,
                Content = reviews.Content,
                Rating = reviews.Rating,
                CreatedAt = reviews.CreatedAt,
                CreatedBy = reviews.CreatedBy,
                ArtPieceId = reviews.ArtPieceId
            };
        }
    }
}