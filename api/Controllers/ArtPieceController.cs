using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.ArtPieceDTOS;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace api.Controllers
{
    [Route("api/artpiece")]
    [ApiController]
    [Authorize(Roles ="User")]
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
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var artPiece = createArtPieceDTO.ToArtPiece();
            await _repoArt.CreateArtPieceAsync(artPiece);
            

            return CreatedAtAction(nameof(GetOneArtwork), new { id = artPiece.Id}, artPiece.ToArtPieceDTO());
        }  

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneArtwork([FromRoute] int id){
            var artwork = await _repoArt.GetOneArtPieceAsync(id);
            if(artwork == null) return NotFound("Art does not exist");
            return Ok(artwork?.ToArtPieceDTO());
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateArtPiece([FromRoute] int id, [FromBody] UpdateArtPieceDTO artPieceDTO){
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var updatedArtPiece = await _repoArt.UpdateArtPieceAsync(id, artPieceDTO);

            if(updatedArtPiece == null) return NotFound("Art does not exist");

            return Ok(updatedArtPiece.ToArtPieceDTO());


        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteArtPiece([FromRoute] int id){
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var deleteArtPiece = await _repoArt.DeleteArtPieceAsync(id);
            if(deleteArtPiece  == null ) return NotFound();

            return NoContent();
        }


    }
}