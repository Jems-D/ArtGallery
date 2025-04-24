using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTO.ArtPieceDTOS;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ApplicationDbContext _context;
        public ReviewRepository(ApplicationDbContext context)
        {   
            _context = context;
        }

        public async Task<Reviews> CreateReviewAsync(Reviews reviews)
        {
            var addReview = await _context.AddAsync(reviews);
            await _context.SaveChangesAsync();
            return reviews;
        }

        public async Task<List<Reviews>> GetAllReviewAsync()
        {
            var reviews = await _context.Reviews
                            .Select(a => new Reviews{
                                Title = a.Title,
                                Content = a.Content,
                                Rating = a.Rating,
                                CreatedAt = a.CreatedAt,
                                ArtPieceId = a.ArtPieceId

                            }).ToListAsync();

            return reviews;
        }

        public async Task<Reviews> GetOneReviewAsync(int id)
        {
            var review = await _context.Reviews.FirstOrDefaultAsync(s => s.Id == id);
            if(review == null) return null;
            return review;
        }
    }
}