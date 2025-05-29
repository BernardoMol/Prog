






//         //==============================================================================================================
//         //============================ Este é o controler antes de migrarmos as partes referentes 
//                                         à conexão com banco de dados para a INTERFACE ==================================
//         //==============================================================================================================
















// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Security.Cryptography.X509Certificates;
// using System.Threading.Tasks;
// using api.Data;
// using api.Dtos;
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

//         // Construtor da classe StockController
//         public StockController(ApplicationDBContext context){
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
//             var stocks = await _context.Stocks.ToListAsync(); // Stocks vem de applicationdbcontext
//             // var stockDto = stocks.Select(s => s.ToStockDto()); // NÃO ENTENDI....N ERA OPARA NÃO FUNCIONAR?????!!!!!!!!!!!!
//             return Ok(stocks);
//         }

//         [HttpGet("{id}")]
//         public async Task<IActionResult> GetById([FromRoute] int id){
//             var stock = await _context.Stocks.FindAsync(id); // Stocks vem de applicationdbcontext
//             if(stock == null){ return NotFound();}         
//             return Ok(stock.ToStockDto());
//         }

//         [HttpPost]
//         public async Task<IActionResult> Create([FromBody] Dtos.CreateStockRequestDto stockDto){ //FormBody é usado pórque vamos passar as informaçãoes via "body"
//             var stockModel = stockDto.ToStockFromCreateDTO();
//             await _context.Stocks.AddAsync(stockModel);
//             await _context.SaveChangesAsync();
//             return CreatedAtAction(nameof(GetById), new {id = stockModel.Id}, stockModel.ToStockDto());
//         }

//         // [HttpPut]
//         // [Route("{id}")]
//         [HttpPut("{id}")] // As duas formas de escrever funcionam
//         public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto){ //FormBody é usado pórque vamos passar as informaçãoes via "body"
//             var stockModel = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
//             if(stockModel == null){
//                 return NotFound();
//             }

//             stockModel.Symbol = updateDto.Symbol;
//             stockModel.CompanyName = updateDto.CompanyName;
//             stockModel.Purchase = updateDto.Purchase;
//             stockModel.LastDiv = updateDto.LastDiv;
//             stockModel.Industry = updateDto.Industry;
//             stockModel.MarketCap = updateDto.MarketCap;

//             await _context.SaveChangesAsync();
//             return Ok(stockModel.ToStockDto());
//         }

//         [HttpDelete("{id}")]
//         public async Task<IActionResult> Delete([FromRoute] int id){
//             var stockModel = await _context.Stocks.FindAsync(id); // Stocks vem de applicationdbcontext
//             // var stockModel = _context.Stocks.FirstOrDefault(x => x.Id == id); // Funcionam da mesma forma? // Menos eficiente e recomendavel quando usar mais filtros // Ele faz uma query
//             if(stockModel == null){ return NotFound();}         
//             _context.Stocks.Remove(stockModel); // ESTA FUNÇÃO É A UNICA QUE NAO PE ASSINCRONA.....DOIDERA...NEM O CARA SABE PQ
//             await _context.SaveChangesAsync();
//             return NoContent();
//         }

//     }
// }