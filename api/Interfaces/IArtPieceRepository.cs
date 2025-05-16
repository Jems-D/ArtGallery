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
         Task<ArtPiece?> GetOneArtPieceAsync(int id);
         Task<ArtPiece> UpdateArtPieceAsync(int id, UpdateArtPieceDTO artPieceDTO);
         Task<ArtPiece> DeleteArtPieceAsync(int id);
         Task<bool> DoesArtPieceExistAsync(int id);
         Task<Ids?> GetExistingCopyAsync(int objcetId);
    }
}