using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTO.ArtPieceDTOS;
using api.DTO.ReviewDTOS;
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

        public async Task<Reviews>? GetOneReviewAsync(int id)
        {
            var review = await _context.Reviews.FirstOrDefaultAsync(s => s.Id == id);
            if(review == null) return null;
            return review;
        }


        public async Task<Reviews> DeleteReviewAsync(int id){
            var existingReview = await _context.Reviews.FirstOrDefaultAsync(s => s.Id == id);
            if(existingReview == null) return null;
            _context.Reviews.Remove(existingReview);
            await _context.SaveChangesAsync();
            return existingReview;
        }

        public async Task<Reviews> UpdateReviewAsync(int id, UpdateReviewDTO reviewDTO)
        {
            var existingReview = await _context.Reviews.FirstOrDefaultAsync(s => s.Id == id);
            if(existingReview == null) return null;

            existingReview.Title = reviewDTO.Title;
            existingReview.Content = reviewDTO.Content;
            existingReview.Rating = reviewDTO.Rating;

            _context.Entry(existingReview).CurrentValues.SetValues(reviewDTO);
            await _context.SaveChangesAsync();
            return existingReview;
        }
    }
}