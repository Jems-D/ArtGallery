using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTO
{
    public class UserDTO
    {
        public required string  Username { get; set; }
        public required string Password { get; set; }
    }
}