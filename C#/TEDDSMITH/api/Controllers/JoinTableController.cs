using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using api.Extentions;
using api.Interfaces;
using api.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{   
    [Route("api/jointable")]
    [ApiController]
    public class JoinTableControler : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IStockRepository _stockRepository;
        private readonly IJoinTableRepository _joinTableRepository;
        public JoinTableControler (UserManager<AppUser> userManager, IStockRepository stockRepository, IJoinTableRepository joinTableRepository)
        {
            _userManager = userManager;
            _stockRepository = stockRepository;
            _joinTableRepository = joinTableRepository;
        }
        
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetJoinTables()
        {   

            // DEBUGANDO ----> OK --> o email esta voltando, com o usuario, tudo certinho
            // var user = HttpContext.User;

            // if (user == null || !user.Identity.IsAuthenticated)
            // {
            // return Unauthorized("Usuário não autenticado.");
            // }

            // // Logando todas as claims do usuário
            // foreach (var claim in user.Claims)
            // {
            // Console.WriteLine($"Claim Type: {claim.Type}, Value: {claim.Value}");
            // }

            // // Agora tenta buscar o e-mail
            // var emailClaim = user.FindFirst(ClaimTypes.Email);

            // if (emailClaim == null)
            // {
            // Console.WriteLine("⚠️ Nenhuma claim de e-mail encontrada!");
            // }
            // else
            // {
            // Console.WriteLine($"✅ E-mail encontrado: {emailClaim.Value}");
            // }



            Console.WriteLine(User);
            var user_email = User.GetUserEmail();
            var appUser = await _userManager.FindByEmailAsync(user_email);
            var userJointables = await _joinTableRepository.GetUserJoinTables(appUser);
            return Ok(userJointables);
        }
        

        [HttpPost] 
        [Authorize]
        public async Task<IActionResult> AddJoinTable(string symbol)
        {
            var user_email = User.GetUserEmail();
            var appUser = await _userManager.FindByEmailAsync(user_email);
            var stock = await _stockRepository.GetBySymbolAsync(symbol);

            if(stock == null) return BadRequest("Stock não encontrada");

            var userJointables = await _joinTableRepository.GetUserJoinTables(appUser);
            if(userJointables.Any(s => s.Symbol.ToLower() == symbol.ToLower())) return BadRequest("Stock já adicionada");

            var joinTableModel = new JoinTable
            {
                StockId = stock.Id,
                AppUserId = appUser.Id
            };

            await _joinTableRepository.CreateAsync(joinTableModel);

            if(joinTableModel == null) {
                return StatusCode(500, "Erro ao adicionar stock");
            }
            else{ 
                return Created();
            };
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteJoinTable(string symbol)
        {
            var user_email = User.GetUserEmail();
            var appUser = await _userManager.FindByEmailAsync(user_email);
            var userJoinTable = await _joinTableRepository.GetUserJoinTables(appUser);

            var filteredStock = userJoinTable.Where(s => s.Symbol.ToLower() == symbol.ToLower()).ToList();
            if(filteredStock.Count == 1) {
                await _joinTableRepository.DeleteJoinTable(appUser, symbol);
            }
            else{
                return BadRequest("Stock não encontrada");
            }

            return Ok();
        }
    }
}