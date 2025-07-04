using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using api.DTO;
using api.Entities;
using api.Interfaces;
using api.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Sprache;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _auth;
        public AuthController(IAuthService auth)
        {
            _auth = auth;
        }
        public static User user = new();
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDTO dto)
        {
            var account = await _auth.RegisterAsync(dto);
            if(account == null) return BadRequest("Username already exist");
            return Ok();
        } 

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserDTO dto)
        {
            var result = await _auth.LoginAsync(dto);
            if(result == null) return BadRequest("Invalid username or password");
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None,
                Expires = DateTime.Now.AddDays(1),
                Path = "/"
            };
                Response.Cookies.Append("authToken", result.AccessToken, cookieOptions);
            
            return Ok(new UserResponseDTO{
                User = result.User,
                Role =result.Role,
                Id = result.Id
            });
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            var cookieOption = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None,
                Expires = DateTime.Now.AddDays(-1),
                Path = "/"
            };
            Response.Cookies.Append("authToken", "", cookieOption);

            return Ok();
        }


        [HttpGet("try")]
        [Authorize]
        public async Task<IActionResult> Try(){
            return Ok("Authorized");
        }

        [HttpPost("refreshtoken")]
        public async Task<IActionResult> RefreshToken(RefreshRequestTokenDTO dto)
        {
            var result = await _auth.RefreshTokensAsync(dto);
            if(result == null)  return BadRequest("Token still valid");

            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None,   //using none will allow cross site origin for differnt front-end url
                Expires = DateTime.Now.AddDays(1),
                Path = "/"
            };
            Response.Cookies.Append("authToken", result.AccessToken, cookieOptions);

            return Ok( new UserResponseDTO{
                User = result.User,
                Role = result.Role,
                Id = result.Id
            });
        }
    }
}