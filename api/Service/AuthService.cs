using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using api.Data;
using api.DTO;
using api.Entities;
using api.Interfaces;
using api.Migrations;
using Azure.Core;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace api.Service
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        public AuthService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<TokenResponseDTO?> LoginAsync(UserDTO dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == dto.Username);
            if(user == null){
                return null;
            }
            if(new PasswordHasher<User>().VerifyHashedPassword(user!, user!.PasswordHash, dto.Password) == PasswordVerificationResult.Failed){
                return null;
            }

            return new TokenResponseDTO{
                AccessToken = CreateToken(user),
                RefreshToken = await GenerateAndSAveRefreshTokenAsync(user),
            };

        } 

        public async Task<User> RegisterAsync(UserDTO dto)
        {

            if(await _context.Users.AnyAsync(u => u.Username == dto.Username)){
                return null;
            }
            var user = new User();
            var hashedPassword = new PasswordHasher<User>()
                .HashPassword(user, dto.Password);
            
            user.Username = dto.Username;
            user.PasswordHash = hashedPassword;

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
            
        }

        private async Task<string> GenerateAndSAveRefreshTokenAsync(User usesr){
            var refreshToken = GenerateRefreshToken();
            usesr.RefreshToken = refreshToken;
            usesr.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            await _context.SaveChangesAsync();
            return refreshToken;
        }

        private string CreateToken(User user){
            var claim = new List<Claim>{
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWT:Token")!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var tokenDescriptor = new JwtSecurityToken(
                issuer: _configuration.GetValue<string>("JWT:Issuer"),
                audience: _configuration.GetValue<string>("JWT:Audience"),
                claims: claim,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );
            return new  JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        } 

    
        private string GenerateRefreshToken(){
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

       
       private async Task<User?> ValidateRefreshTokenAsync(Guid id, string refreshToken){
            var user = await _context.Users.FindAsync(id);
            if(user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.UtcNow){
                return null;
            }
            return user;
       }

        public async Task<TokenResponseDTO?> RefreshTokensAsync(RefreshRequestTokenDTO dto)
        {
            var user = await ValidateRefreshTokenAsync(dto.Id, dto.RefreshToken);
            if(user == null) return null;
            return new TokenResponseDTO{
                AccessToken = CreateToken(user),
                RefreshToken = await GenerateAndSAveRefreshTokenAsync(user),
            };

        }
    }
}