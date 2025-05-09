using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using api.Interfaces;
using api.models;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;

namespace api.Services
{
    public class TokenService : ITokenService
    {

        //==============================================================================================================
        //------------------------ ESSA DOIDERA TODA (aula 23) É PARA CRIAR UM TOKEN PARA O USUARIO --------------------
        //==============================================================================================================
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _key; 
        public TokenService(IConfiguration config)  
        {
            _config = config;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SigningKey"]));
        
        }
        public string CreateToken(AppUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.GivenName, user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email), // Aparentemente a ordem NÃO importa
                //new Claim(JwtRegisteredClaimNames.GivenName, user.UserName),
            };

            {
                var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddDays(7),
                    SigningCredentials = creds,
                    Issuer = _config["JWT:Issuer"],
                    Audience = _config["JWT:Audience"]
                };

                var tokenHandler = new JwtSecurityTokenHandler();

                var token = tokenHandler.CreateToken(tokenDescriptor);

                return tokenHandler.WriteToken(token);
            }
        }
        //==============================================================================================================
        //------------------------ FIM DA DOIDERA DA AULA 23 ----------------------------------------------------------
        //==============================================================================================================
    }
}