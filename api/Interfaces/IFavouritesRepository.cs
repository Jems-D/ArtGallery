using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.ArtPieceDTOS;
using api.Entities;
using api.Models;

namespace api.Interfaces
{
    public interface IFavouritesRepository
    {
        Task<Favourites> AddArtPieceToFavourites(Favourites favs);
        Task<bool> DoesArtPieceAlreadyExistAsync(Guid userId, int Id);
        Task<List<ArtPiece>> GetAllFavourites(User user);
        Task<Favourites> RemoveArtFromFavAsync(Guid userId, int  objectId);


    }
}