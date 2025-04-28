using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO;
using api.Entities;

namespace api.Interfaces
{
    public interface IAuthService
    {
        Task<User> RegisterAsync(UserDTO dto);
        Task<TokenResponseDTO?> LoginAsync(UserDTO dto);
        Task<TokenResponseDTO?> RefreshTokensAsync(RefreshRequestTokenDTO dto);
    
    }
}