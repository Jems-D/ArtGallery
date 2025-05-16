using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using api.DTO.ReviewDTOS;
using api.Extensions;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/review")]
    [ApiController]
    [Authorize(Roles = "User")]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewRepository _repoReview;
        private readonly IArtPieceRepository _repoArt;
        private readonly IHarvardMuseuemApiRepository _repoMuseum;
        private readonly IAuthService _auth;
        public ReviewsController(IReviewRepository repoReview, IArtPieceRepository repoArt, 
                        IHarvardMuseuemApiRepository repoMuseum, IAuthService auth)
        {
            _repoReview = repoReview;
            _repoArt = repoArt;
            _repoMuseum = repoMuseum;
            _auth = auth;
        }    

        [HttpPost("{objectId:int}")]
        public async Task<IActionResult> CreateReview([FromRoute] int objectId, [FromBody] CreateReviewDTO reviewDTO)
        {
            //var isExist = await _repoArt.DoesArtPieceExistAsync(id);
            //if(!isExist) return BadRequest("No art piece found");
            var  existingCopy = await _repoArt.GetExistingCopyAsync(objectId);
            ArtPiece newArtPiece = null;
            if(existingCopy == null){
                var newCopy = await _repoMuseum.GetObjectInformation(objectId);
                if(newCopy == null){
                    return BadRequest("This object does not exist");
                    
                }else{
                    newArtPiece = newCopy.ToArtPieceFromMetadata()!;
                    await _repoArt.CreateArtPieceAsync(newArtPiece);
                }
            }

            var username = User.GetUserName(); 
            if(username == null)return BadRequest("Can't create a review, because username cannot be found");
            var userClaimId = User.FindFirstValue(ClaimTypes.NameIdentifier);   // get the UserID of the user
            var review = reviewDTO.ToReview(existingCopy == null ? (int)newArtPiece.Id : (int)existingCopy.Id);              

            if(existingCopy != null){
                review.ObjectId = existingCopy.ObjectId;
            }else{
                review.ObjectId = (int)newArtPiece.ObjectId;
            }


            if(Guid.TryParse(userClaimId, out Guid userId)){
                 review.UserId = userId; //add userId to it
            }else{
                return BadRequest("Invalid Id");
            }
           
            review.CreatedBy = username; //add the username to the review creation dto
            
            
            await _repoReview.CreateReviewAsync(review);

            return CreatedAtAction(nameof(GetOneReview), new {id = review.Id}, review.ToReviewDTO());
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReviews([FromQuery] ReviewQuery query){
            var reviews = await _repoReview.GetAllReviewAsync(query);
            return Ok(reviews);
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