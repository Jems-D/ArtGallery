using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTO
{
    public class TokenResponseDTO
    {
        public required string AccessToken { get; set; }
        public required string RefreshToken { get; set; }
        public required string User { get; set; }
        public required Guid Id { get; set; }
        public required string Role { get; set; }
    }

    public class UserResponseDTO{
        public required string User { get; set; }
        public required string Role { get; set; }
        public  required Guid Id { get; set; }
    }
}