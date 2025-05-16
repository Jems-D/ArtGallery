using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.ArtPieceDTOS;
using api.DTO.ReviewDTOS;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface IReviewRepository
    {
        Task<Reviews> CreateReviewAsync(Reviews reviews);
        Task<ReviewResultsDTO<ReviewDTO>> GetAllReviewAsync(ReviewQuery query);
        Task<Reviews>? GetOneReviewAsync(int id);
        Task<Reviews> DeleteReviewAsync(int id);
        Task<Reviews> UpdateReviewAsync(int id, UpdateReviewDTO reviewDTO);
    }
}