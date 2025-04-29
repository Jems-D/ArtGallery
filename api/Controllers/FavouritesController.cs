using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using api.Extensions;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/favourites")]
    [ApiController]
    [Authorize(Roles ="User")]
    public class FavouritesController : ControllerBase
    {
        private readonly IFavouritesRepository _repoFav;
        private readonly IArtPieceRepository _repoArt;
        private readonly IAuthService _auth;
        private readonly IHarvardMuseuemApiRepository _repoMuseum;
        public FavouritesController(IFavouritesRepository repoFav, IArtPieceRepository repoArt, IAuthService auth, IHarvardMuseuemApiRepository repoMusuem)
        {
            _repoFav = repoFav;
            _repoArt = repoArt;
            _auth = auth;
            _repoMuseum = repoMusuem;
        }

        [HttpGet]
        public async Task<IActionResult> GetFavouritesList(){
            var userName = User.GetUserName();
            var user = await _auth.FindByNameAsync(userName);
            if(user == null) return BadRequest("No user, no list");
            var list = await _repoFav.GetAllFavourites(user);
            return Ok(list.Select(s=> s.ToArtPieceFavFromArtPiece()));
        }

        [HttpPost("{objectId:int}")]
        public async Task<IActionResult> AddToFavourites([FromRoute]int objectId){
            var user = (Guid)User.GetUserId();

            var existingCopy = await _repoArt.GetExistingCopyAsync(objectId);
            ArtPiece newArtPiece = null;
            if(existingCopy == null || existingCopy == 0){
                var newCopy = await _repoMuseum.GetObjectInformation(objectId);
                if(newCopy == null){
                    return BadRequest("ArtPiece does not exist");
                }else{
                    newArtPiece = newCopy.ToArtPieceFromMetadata()!;
                    await _repoArt.CreateArtPieceAsync(newArtPiece);
                }
            }

            var id = existingCopy == null ? newArtPiece.Id : (int)existingCopy; 
            
            if(await _repoFav.DoesArtPieceAlreadyExistAsync(user, id)){
                return BadRequest("Art Piece Already Added");
            }

            var fav = new Favourites{
                UserId = user,
                ArtPieceId = id
            };

            var favourites = await _repoFav.AddArtPieceToFavourites(fav);
            if(favourites == null){
                return StatusCode(500, "Something wrong");
            }
            return Created();

        }
        
        [HttpDelete("{objectId:int}")]
        public async Task<IActionResult> RemoveFromFavs([FromRoute] int objectId){
            var userId = (Guid)User.GetUserId();
            var deleted = await _repoFav.RemoveArtFromFavAsync(userId, objectId);
            if(deleted == null) return NotFound("Not found");
            return NoContent();

        }
    }
}