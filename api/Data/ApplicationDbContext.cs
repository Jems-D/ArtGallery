using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Entities;
using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Favourites>(s => s.HasKey(p=> new { p.UserId, p.ArtPieceId}));
            modelBuilder.Entity<Favourites>()
                .HasOne(p => p.User)
                .WithMany(u => u.Favourites)
                .HasForeignKey(f => f.UserId);

            modelBuilder.Entity<Favourites>()
                .HasOne(p => p.ArtPiece)
                .WithMany(p => p.favourites)
                .HasForeignKey(f => f.ArtPieceId);
        }

        public DbSet<ArtPiece> ArtPiece { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Favourites> Favourites { get; set; }
    }
}