// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Security.Cryptography.X509Certificates;
// using System.Threading.Tasks;
// using api.Data;
// using api.Dtos;
// using api.Interfaces;
// using api.Mappers;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.Identity.Client.Extensions.Msal;

// namespace api.Controllers
// {
//     [ApiController]
//     [Route("api/stock")]

//     public class StockController : ControllerBase
//     {
//         // Parametros da classe StockController
//         private readonly ApplicationDBContext _context;
//         private readonly IStockRepository _stockRepo;
//         // Construtor da classe StockController
//         public StockController(ApplicationDBContext context, IStockRepository stockRepo){
//             _stockRepo = stockRepo;
//             _context = context;
//         }

//         // // Métodos da da classe StockController

//         //==============================================================================================================
//         //============================ ESTRUTURA SÍNCRONA DE USAR OS MÉTODOS ===========================================
//         //==============================================================================================================

//         // [HttpGet]
//         // public IActionResult GetALL(){
//         //     var stocks = _context.Stocks.ToList() // Stocks vem de applicationdbcontext
//         //     .Select(s => s.ToStockDto());
//         //     return Ok(stocks);
//         // }

//         // [HttpGet("{id}")]
//         // public IActionResult GetById([FromRoute] int id){
//         //     var stock = _context.Stocks.Find(id); // Stocks vem de applicationdbcontext
//         //     if(stock == null){ return NotFound();}         
//         //     return Ok(stock.ToStockDto());
//         // }

//         // [HttpPost]
//         // public IActionResult Create([FromBody] Dtos.CreateStockRequestDto stockDto){ //FormBody é usado pórque vamos passar as informaçãoes via "body"
//         //     var stockModel = stockDto.ToStockFromCreateDTO();
//         //     _context.Stocks.Add(stockModel);
//         //     _context.SaveChanges();
//         //     return CreatedAtAction(nameof(GetById), new {id = stockModel.Id}, stockModel.ToStockDto());
//         // }

//         // // [HttpPut]
//         // // [Route("{id}")]
//         // [HttpPut("{id}")] // As duas formas de escrever funcionam
//         // public IActionResult Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto){ //FormBody é usado pórque vamos passar as informaçãoes via "body"
//         //     var stockModel = _context.Stocks.FirstOrDefault(x => x.Id == id);
//         //     if(stockModel == null){
//         //         return NotFound();
//         //     }

//         //     stockModel.Symbol = updateDto.Symbol;
//         //     stockModel.CompanyName = updateDto.CompanyName;
//         //     stockModel.Purchase = updateDto.Purchase;
//         //     stockModel.LastDiv = updateDto.LastDiv;
//         //     stockModel.Industry = updateDto.Industry;
//         //     stockModel.MarketCap = updateDto.MarketCap;

//         //     _context.SaveChanges();
//         //     return Ok(stockModel.ToStockDto());
//         // }

//         // [HttpDelete("{id}")]
//         // public IActionResult Delete([FromRoute] int id){
//         //     var stockModel = _context.Stocks.Find(id); // Stocks vem de applicationdbcontext
//         //     // var stockModel = _context.Stocks.FirstOrDefault(x => x.Id == id); // Funcionam da mesma forma? // Menos eficiente e recomendavel quando usar mais filtros // Ele faz uma query
//         //     if(stockModel == null){ return NotFound();}         
//         //     _context.Stocks.Remove(stockModel);
//         //     _context.SaveChanges();
//         //     return NoContent();
//         // }


//         //==============================================================================================================
//         //============================ ASSÍNCRONO ===========================================
//         //==============================================================================================================

//         [HttpGet]
//         public async Task<IActionResult> GetALL(){

//             if(!ModelState.IsValid) // Esta é a forma de validar se os dados passados pelo usuario CONDIZEM com os que estao no modelo c
//                 return BadRequest(ModelState);

//             var stocks = await _stockRepo.GetAllAsync();
//             // var stockDto = stocks.Select(s => s.ToStockDto()); // NÃO ENTENDI....N ERA OPARA NÃO FUNCIONAR?????!!!!!!!!!!!!
//             return Ok(stocks);
//         }

//         [HttpGet("{id:int}")]
//         public async Task<IActionResult> GetById([FromRoute] int id){

//             if(!ModelState.IsValid) // Esta é a forma de validar se os dados passados pelo usuario CONDIZEM com os que estao no modelo c
//                 return BadRequest(ModelState);

//             var stock = await _stockRepo.GetByIdAsync(id); // Stocks vem de applicationdbcontext
//             if(stock == null){ return NotFound();}         
//             return Ok(stock.ToStockDto());
//         }

//         [HttpPost]
//         public async Task<IActionResult> Create([FromBody] Dtos.CreateStockRequestDto stockDto){ //FormBody é usado pórque vamos passar as informaçãoes via "body"
            
//             if(!ModelState.IsValid) // Esta é a forma de validar se os dados passados pelo usuario CONDIZEM com os que estao no modelo c
//                 return BadRequest(ModelState);

//             var stockModel = stockDto.ToStockFromCreateDTO();
//             await _stockRepo.CreateAsync(stockModel);
//             return CreatedAtAction(nameof(GetById), new {id = stockModel.Id}, stockModel.ToStockDto());
//         }

//         // [HttpPut]
//         // [Route("{id}")]
//         [HttpPut("{id:int}")] // As duas formas de escrever funcionam
//         public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto){ //FormBody é usado pórque vamos passar as informaçãoes via "body"
            
//             if(!ModelState.IsValid) // Esta é a forma de validar se os dados passados pelo usuario CONDIZEM com os que estao no modelo c
//                 return BadRequest(ModelState);

//             var stockModel = await _stockRepo.UpdateAsync(id, updateDto);
//             if(stockModel == null){
//                 return NotFound();
//             } 
//             return Ok(stockModel.ToStockDto());
//         }

//         [HttpDelete("{id:int}")]
//         public async Task<IActionResult> Delete([FromRoute] int id){
            
//             if(!ModelState.IsValid) // Esta é a forma de validar se os dados passados pelo usuario CONDIZEM com os que estao no modelo c
//                 return BadRequest(ModelState);
                
//             var stockModel = await _stockRepo.DeleteAsync(id);
//             if(stockModel == null){
//                 return NotFound();
//             } 
//             return NoContent();
//         }

//     }
// }