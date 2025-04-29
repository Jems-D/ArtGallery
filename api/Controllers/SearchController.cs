using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.HarvardMusemApiDTOS;
using api.Helpers.HarvardMuseumQueries;
using api.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace api.Controllers
{
    [Route("api/search")]
    [ApiController]
    [Authorize(Roles = "User")]
    public class SearchController : ControllerBase
    {
        private readonly IHarvardMuseuemApiRepository _repoMuseum;
        public SearchController(IHarvardMuseuemApiRepository repoMuseum)
        {
            _repoMuseum = repoMuseum;
        }


        [HttpGet]
        public async Task<IActionResult> GetArtPiecesBasedOnKeywords([FromQuery]KeywordSearchQuery searchQuery){
            var result = await _repoMuseum.GetArtworksBasedOnKeywords(searchQuery);
            if(result == null){
                return NotFound("No results were found");
            }
            return Ok(result);
        }

        [HttpGet("category")]
        public async Task<IActionResult> GetProperties([FromQuery] PropSearchQuery query){
            var properties = await _repoMuseum.FindProperties(query);
            if(properties == null) return NotFound("No sub-properties found");
            return Ok(properties);
        }

        [HttpGet("category/artpieces")]
        public async Task<IActionResult> GetArtPieces([FromQuery] ArtPieceSearchQuery searchQuery){
            var artpieces = await _repoMuseum.GetArtWorks(searchQuery);
            if(artpieces == null) return NotFound("No artworks found");
            return Ok(artpieces);
        }

        [HttpGet("artpieceinfo/{objectId:int}")]
        public async Task<IActionResult> GetArtPieceInformation([FromRoute] int objectId){
            var artpieceInfo = await _repoMuseum.GetObjectInformation(objectId);
            if(artpieceInfo == null){
                return NotFound("No information found");
            }
            return Ok(artpieceInfo);
        }
        [HttpGet("related/{objectId:int}")]
        public async Task<IActionResult> GetRelatedArtworks([FromRoute] int objectId){
            var relatedArts = await _repoMuseum.GetArtworkdsRelatedToObject(objectId);
            if(relatedArts == null) return NoContent();
            return Ok(relatedArts);
        }

        [HttpGet("exhibitions/{objectId:int}")]
        public async Task<IActionResult> GetExhibitions([FromRoute] int objectId){
            var exhibitions = await _repoMuseum.GetExhibitionListOfArtwork(objectId);
            if(exhibitions == null){
                return NoContent();
            }
            return Ok(exhibitions);
        }

        [HttpGet("publications/{objectId:int}")]
        public async Task<IActionResult> GetPublications([FromRoute] int objectId){
            var publications = await _repoMuseum.GetPublicationsListOfArtwork(objectId);
            if(publications == null) return NoContent();
            return Ok(publications);
        }

        [HttpGet("otherartworks")]
        public async Task<IActionResult> GetOtherArtWorksByPerson([FromQuery] GetOtherArtworksQuery query){
            try{
                var otherArtworks = await _repoMuseum.GetOtherArtworks(query);
                if(otherArtworks == null) return NoContent();
                return Ok(otherArtworks);
            }catch(Exception ex){
                return NotFound(ex.Message);
            }   
            
        }


    }
}