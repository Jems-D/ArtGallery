using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTO.ArtPieceDTOS;
using api.DTO.ReviewDTOS;
using api.Helpers;
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
            var addReview = await _context.Reviews.AddAsync(reviews);
            await _context.SaveChangesAsync();
            return reviews;
        }

        public async Task<ReviewResultsDTO<ReviewDTO>> GetAllReviewAsync(ReviewQuery query)
        {
            var totalCount = await _context.Reviews.Where(s=> s.ObjectId == query.ObjectId).CountAsync();

            var reviews = _context.Reviews
                            .Include(a => a.User)
                            .Select(a => new Reviews
                            {
                                Title = a.Title,
                                Content = a.Content,
                                Rating = a.Rating,
                                CreatedAt = a.CreatedAt,
                                ArtPieceId = a.ArtPieceId,
                                CreatedBy = a.CreatedBy,
                                ObjectId = a.ObjectId,
                                Id = a.Id

                            }).AsQueryable();

            if(query.ObjectId is not 0){ //pattern matching
                reviews = reviews
                    .Where(i => i.ObjectId == query.ObjectId);
            }

            if(!query.IsDescending){
                reviews = reviews.OrderByDescending(s => s.CreatedAt);
            }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            var reviewsList =  await reviews.Skip(skipNumber).Take(query.PageSize).ToListAsync();

            var result = new ReviewResultsDTO<ReviewDTO>{
                pageNumber = query.PageNumber,
                totalCount = totalCount,
                reviews = reviewsList.Select(s=> s.ToReviewDTO()).ToList(),
                pageSize = query.PageSize
            };
            return result;



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