using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTO.ArtPieceDTOS;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ArtPieceRepository : IArtPieceRepository
    {
        private readonly ApplicationDbContext _context;
        public ArtPieceRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ArtPiece> CreateArtPieceAsync(ArtPiece artPieceProperties)
        {
            await _context.ArtPiece.AddAsync(artPieceProperties);
            await _context.SaveChangesAsync();
            return artPieceProperties;
            
        }

        public async Task<ArtPiece> DeleteArtPieceAsync(int id)
        {
            var artPiece = await _context.ArtPiece.FirstOrDefaultAsync(a => a.Id == id);
            if(artPiece == null) return null;

            _context.ArtPiece.Remove(artPiece);
            await _context.SaveChangesAsync();
            return artPiece;

            
        }

        public async Task<bool> DoesArtPieceExistAsync(int id)
        {
            return await _context.ArtPiece.AnyAsync(a => a.Id == id);
        }

        public async Task<List<ArtPiece>> GetAllArtPieceAsync()
        {
             var artworks = await _context.ArtPiece
                .Include(r => r.reviews)
                .Select(a => new ArtPiece
                {
                    Title = a.Title, 
                    Meduim = a.Meduim, 
                    Classification = a.Classification, 
                    Technique = a.Technique, 
                    Dimensions = a.Dimensions, 
                    Culture = a.Culture, 
                    Description = a.Description,  
                    reviews = a.reviews,
                    })
                .ToListAsync();
            return artworks;

        }

        public async Task<Ids?> GetExistingCopyAsync(int objcetId)
        {
            var existingCopy = await _context.ArtPiece
                                .Where(s => s.ObjectId == objcetId)
                                .Select(s=> new Ids{
                                    Id = s.Id,
                                    ObjectId = (int)s.ObjectId
                                })
                                .FirstOrDefaultAsync();
            if(existingCopy == null) return null;
            return existingCopy;
                                
        }

        public async Task<ArtPiece?> GetOneArtPieceAsync(int id)
        {
            var artwork = await _context.ArtPiece
                .Where(a => a.Id == id)
                .Select(a => new ArtPiece
                {
                    Title = a.Title,
                    Meduim = a.Meduim,
                    Classification = a.Classification,
                    Technique = a.Technique,
                    Dimensions = a.Dimensions,
                    Culture = a.Culture,
                    Description = a.Description,
                    DateCreated = a.DateCreated})
                .FirstOrDefaultAsync();

                if(artwork == null) return null;
            return artwork;

        }

        public async Task<ArtPiece> UpdateArtPieceAsync(int id, UpdateArtPieceDTO artPieceDTO)
        {
            var artPiece = await _context.ArtPiece.FirstOrDefaultAsync(a => a.Id == id);
            if(artPiece == null) return null;

            artPiece.Title = artPieceDTO.Title;
            artPiece.Meduim = artPieceDTO.Meduim;
            artPiece.Classification = artPieceDTO.Classification;
            artPiece.Technique = artPieceDTO.Technique;
            artPiece.Dimensions = artPieceDTO.Dimensions;
            artPiece.Culture = artPieceDTO.Culture;
            artPiece.Description = artPieceDTO.Description;

            _context.Entry(artPiece).CurrentValues.SetValues(artPieceDTO);

            await _context.SaveChangesAsync();

            return artPiece;
            
        }
    }
}