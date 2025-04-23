using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.ArtPieceDTOS;
using api.Models;

namespace api.Interfaces
{
    public interface IArtPieceRepository
    {
         Task<ArtPiece> CreateArtPieceAsync(ArtPiece artPieceProperties);
         Task<List<ArtPiece>> GetAllArtPieceAsync();
    }
}