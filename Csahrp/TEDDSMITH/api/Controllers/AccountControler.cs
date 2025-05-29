using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Dtos.Account;
using api.Interfaces;
using api.models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountControler :  ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountControler(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager){
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var user_by_email = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == loginDto.Email.ToLower());// PRIMEIRO VEMOS SE O USUARIO COM ESSE EMAIL EXISTE
            if (user_by_email == null) return Unauthorized("Invalid Email"); 
            var result = await _signInManager.CheckPasswordSignInAsync(user_by_email, loginDto.Password, false);// DEPOIS FALAMOS SE EMAIL/SENHA BATEU
            if (!result.Succeeded) return Unauthorized("Email not Found and/or password incorrect"); 

            return Ok(
                new NewUserDto{
                    UserName = user_by_email.UserName,
                    Email = user_by_email.Email,
                    Token = _tokenService.CreateToken(user_by_email)
                }
            );

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto){
            try{
                if(!ModelState.IsValid){
                    return BadRequest(ModelState);
                };

                var appUser = new AppUser
                {
                    UserName = registerDto.Username,
                    Email = registerDto.Email
                };

                var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password);

                if(createdUser.Succeeded){
                    var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
                    if(roleResult.Succeeded){
                        // return Ok("User created");
                        return Ok(new NewUserDto{
                            UserName = appUser.UserName,
                            Email = appUser.Email,
                            Token = _tokenService.CreateToken(appUser)
                        });
                    } else{
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else{
                    return StatusCode(500, createdUser.Errors);
                }
            } catch (Exception e) {
                return StatusCode(500, e);
            }
        }
    }
}