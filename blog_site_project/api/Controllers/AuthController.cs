using api.DTOs.AuthDTOs;
using api.Models;
using api.Responses.AuthResponses;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;

namespace api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;

        public AuthController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserDTO registerUserDTO)
        {
            
            var newUser = new AppUser
            {
                UserName = registerUserDTO.Username,
                Email = registerUserDTO.Email,
                CreatedAt = DateTime.Now.ToUniversalTime()
            };

            var result = await _userManager.CreateAsync(newUser, registerUserDTO.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            

            return Ok(new RegisterUserResponse
            {
                Username = newUser.UserName,
                Email = newUser.Email,
                Token = await _tokenService.CreateTokenAsync(newUser)
            });

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserDTO loginUserDTO)
        {
            var user = await _userManager.FindByNameAsync(loginUserDTO.Username);

            if (user == null)
            {
                return Unauthorized("Invalid Username or Password!");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user!, loginUserDTO.Password, false);

            if(!result.Succeeded)
            {
                return Unauthorized("Invalid Username or Password!");
            }

            return Ok(new LoginUserResponse
            {
                Username = user.UserName,
                Email = user.Email,
                Token = await _tokenService.CreateTokenAsync(user)
            });

        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return Ok(new { message = "Successfully logged out." });
        }
    }
}
