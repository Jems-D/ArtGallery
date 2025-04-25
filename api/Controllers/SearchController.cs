using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Helpers.HarvardMuseumQueries;
using api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace api.Controllers
{
    [Route("api/search")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IHarvardMuseuemApiRepository _repoMuseum;
        public SearchController(IHarvardMuseuemApiRepository repoMuseum)
        {
            _repoMuseum = repoMuseum;
        }

        [HttpGet]
        public async Task<IActionResult> GetProperties([FromQuery] PropSearchQuery query){
            var regions = await _repoMuseum.FindProperties(query);
            if(regions == null) return NotFound("No regions found");
            return Ok(regions);
        }

        [HttpGet("artpieces")]
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

    }
}