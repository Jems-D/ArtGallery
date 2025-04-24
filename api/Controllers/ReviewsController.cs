using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.ReviewDTOS;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/review")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewRepository _repoReview;
        private readonly IArtPieceRepository _repoArt;
        public ReviewsController(IReviewRepository repoReview, IArtPieceRepository repoArt)
        {
            _repoReview = repoReview;
            _repoArt = repoArt;
        }    

        [HttpPost("{id:int}")]
        public async Task<IActionResult> CreateReview([FromRoute] int id, [FromBody] CreateReviewDTO reviewDTO)
        {
            var isExist = await _repoArt.DoesArtPieceExistAsync(id);
            if(!isExist) return BadRequest("No art piece found");

            var review = await _repoReview.CreateReviewAsync(reviewDTO.ToReview(id));

            return CreatedAtAction(nameof(GetOneReview), new {id = review.Id}, review.ToReviewDTO());
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReviews(){
            var reviews = await _repoReview.GetAllReviewAsync();
            return Ok(reviews.Select(s => s.ToReviewDTO()));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneReview([FromRoute] int id){
            var review = await _repoReview.GetOneReviewAsync(id);
            if(review == null) return NotFound("No review exists");

            return Ok(review.ToReviewDTO()); 
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteReview([FromRoute] int id){
            var review = await _repoReview.DeleteReviewAsync(id);
            if(review == null) return NotFound("No review found");
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateReview([FromRoute] int id, UpdateReviewDTO reviewDTO){
            var updatedReview = await _repoReview.UpdateReviewAsync(id, reviewDTO);
            if(updatedReview ==null) return NotFound("No review found for update");

            return Ok(updatedReview.ToReviewDTO());

        }
    }
}