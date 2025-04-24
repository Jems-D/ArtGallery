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

        [HttpGet("regions")]
        public async Task<IActionResult> GetAllRegions(){
            var regions = await _repoMuseum.FindRegions();
            if(regions == null) return NotFound("No regions found");
            return Ok(regions);
        }

        [HttpGet("countries/{parentId:int}")]
        public async Task<IActionResult> GetAllCountriesFromARegion([FromRoute] int parentId){
            var countries = await _repoMuseum.FindCountries(parentId);
            if(countries == null) return NotFound("No countries found");
            return Ok(countries);
        }

        [HttpGet("artpieces")]
        public async Task<IActionResult> GetArtPieces([FromQuery] ArtPieceSearchQuery searchQuery){
            var artpieces = await _repoMuseum.GetArtWorks(searchQuery);
            if(artpieces == null) return NotFound("No artworks found");
            return Ok(artpieces);
        }
    }
}