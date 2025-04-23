using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.ArtPieceDTOS;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace api.Controllers
{
    [Route("api/artpiece")]
    [ApiController]
    public class ArtPieceController : ControllerBase
    {
        private readonly IArtPieceRepository _repoArt;
        public ArtPieceController(IArtPieceRepository repoArt)
        {
            _repoArt = repoArt;
        }

        [HttpGet]
        public async Task<IActionResult> GetALlArtworks(){
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var artworks = await _repoArt.GetAllArtPieceAsync();
            var artWorksDTO = artworks.Select(s => s.ToArtPieceDTO());

            return Ok(artWorksDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CreateArtPiece([FromBody] CreateArtPieceDTO createArtPieceDTO){
            var artPiece = createArtPieceDTO.ToArtPiece();
            var createdArtPiece = await _repoArt.CreateArtPieceAsync(artPiece);
            return Ok("Stocks Created");
        }  

    }
}