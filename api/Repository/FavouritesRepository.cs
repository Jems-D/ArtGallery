using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTO.ArtPieceDTOS;
using api.Entities;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
   
    public class FavouritesRepository : IFavouritesRepository
    {
         private readonly ApplicationDbContext _context;

         public FavouritesRepository(ApplicationDbContext context)
         {
            _context = context;
         }
        public async Task<Favourites> AddArtPieceToFavourites(Favourites favs)
        {
            var newArtPiece = await _context.Favourites.AddAsync(favs);
            await _context.SaveChangesAsync();
            return favs;
        }


        public async Task<bool> DoesArtPieceAlreadyExistAsync(Guid userId, int id)
        {
            var exisitngArt = await _context.Favourites
                                .Where(s => s.UserId == userId)
                                .AnyAsync(s => s.ArtPieceId == id);
            return exisitngArt;
        }

        public async Task<List<ArtPiece>> GetAllFavourites(User user)
        {
            var list = await _context.Favourites
                        .Where(u => u.UserId == user.Id)
                        .Select(s=> new ArtPiece
                        {
                            Title = s.ArtPiece.Title,
                            ImageUrl = s.ArtPiece.ImageUrl,
                            DateCreated = s.ArtPiece.DateCreated,
                            ObjectId = s.ArtPiece.ObjectId
                        }).ToListAsync();
            return list;
        }

        public async Task<Favourites> RemoveArtFromFavAsync(Guid userId, int objectId)
        {
            var existingArt = await _context.Favourites.FirstOrDefaultAsync(u => u.UserId == userId && u.ArtPiece.ObjectId == objectId);
            if(existingArt == null) return null;
            _context.Favourites.Remove(existingArt);
            await _context.SaveChangesAsync();
            return existingArt;
        }
    }
}