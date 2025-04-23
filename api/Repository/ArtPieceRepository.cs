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

        public async Task<List<ArtPiece>> GetAllArtPieceAsync()
        {
             var artworks = await _context.ArtPiece
                .Select(a => new ArtPiece
                {
                    Title = a.Title, 
                    Artist = a.Artist, 
                    Meduim = a.Meduim, 
                    Classification = a.Classification, 
                    Technique = a.Technique, 
                    Dimensions = a.Dimensions, 
                    Genre = a.Genre, 
                    Description = a.Description, 
                    Location = a.Location, 
                    DateCreated = a.DateCreated})
                .ToListAsync(); //Linq query to optimize
            return artworks;

        }
    }
}