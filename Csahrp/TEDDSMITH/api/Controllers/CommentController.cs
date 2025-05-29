using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using api.Data;
using api.Dtos;
using api.Extentions;
using api.Interfaces;
using api.Mappers;
using api.models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.Extensions.Msal;
using Microsoft.VisualBasic;

namespace api.Controllers
{
    [ApiController]
    [Route("api/comment")]
    public class CommentController : ControllerBase
    {
        // Parametros da classe StockController
        private readonly ApplicationDBContext _context;
        private readonly ICommentRepository _commentRepo;
        private readonly IStockRepository _stockRepo;
        private readonly UserManager<AppUser> _userManager;
        // Construtor da classe StockController
        public CommentController(ApplicationDBContext context, ICommentRepository commentRepo, IStockRepository stockRepo, UserManager<AppUser> userManager){
            _commentRepo = commentRepo;
            _context = context;
            _stockRepo = stockRepo;
            _userManager = userManager;
        }


        [HttpGet]
        public async Task<IActionResult> GetALL(){

            if(!ModelState.IsValid) // Esta é a forma de validar se os dados passados pelo usuario CONDIZEM com os que estao no modelo c
                return BadRequest(ModelState);
            
            var comments = await _commentRepo.GetAllAsync();
            var commentDto = comments.Select(s => s.ToCommentDto()); 
            return Ok(commentDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id){

            if(!ModelState.IsValid) // Esta é a forma de validar se os dados passados pelo usuario CONDIZEM com os que estao no modelo c
                return BadRequest(ModelState);

            var comment = await _commentRepo.GetByIdAsync(id); // Stocks vem de applicationdbcontext
            if(comment == null){ return NotFound();}         
            return Ok(comment.ToCommentDto());
        }

        [HttpPost ("{stockId:int}")]
        public async Task<IActionResult> Create([FromRoute] int stockId, CreateCommentRequestDto commentDto){ //FormBody é usado pórque vamos passar as informaçãoes via "body"            
            
            if(!ModelState.IsValid) // Esta é a forma de validar se os dados passados pelo usuario CONDIZEM com os que estao no modelo c
                return BadRequest(ModelState);

            if(!await _stockRepo.StockExtists(stockId)){
                return BadRequest("Stock does not EXISTS");
            }
            
            var useremail = User.GetUserEmail();
            var appUser = await _userManager.FindByEmailAsync(useremail);

            var commentModel = commentDto.ToCommentFromCreateDTO(stockId);
            commentModel.AppUserId = appUser.Id;
            await _commentRepo.CreateAsync(commentModel);
            return CreatedAtAction(nameof(GetById), new {id = commentModel.Id}, commentModel.ToCommentDto());
        }

        [HttpPut("{id:int}")] // As duas formas de escrever funcionam
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateRequestCommentDto updateDto){ //FormBody é usado pórque vamos passar as informaçãoes via "body"
            
            if(!ModelState.IsValid) // Esta é a forma de validar se os dados passados pelo usuario CONDIZEM com os que estao no modelo c
                return BadRequest(ModelState);
            
            var commentModel = await _commentRepo.UpdateAsync(id, updateDto.ToCommentFromUpdate());
            if(commentModel == null){
                return NotFound();
            } 
            return Ok(commentModel.ToCommentDto());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id){

            if(!ModelState.IsValid) // Esta é a forma de validar se os dados passados pelo usuario CONDIZEM com os que estao no modelo c
                return BadRequest(ModelState);

            var commentModel = await _commentRepo.DeleteAsync(id);
            if(commentModel == null){
                return NotFound();
            } 
            return NoContent();
        }

    }
}