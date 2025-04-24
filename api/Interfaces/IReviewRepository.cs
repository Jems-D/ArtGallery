using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.ArtPieceDTOS;
using api.Models;

namespace api.Interfaces
{
    public interface IReviewRepository
    {
        Task<Reviews> CreateReviewAsync(Reviews reviews);
        Task<List<Reviews>> GetAllReviewAsync();
        Task<Reviews> GetOneReviewAsync(int id);
    }
}