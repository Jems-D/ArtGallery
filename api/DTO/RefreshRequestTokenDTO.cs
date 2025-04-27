using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTO
{
    public class RefreshRequestTokenDTO
    {
        public Guid Id { get; set; }
        public required string RefreshToken { get; set; } 
    }
}