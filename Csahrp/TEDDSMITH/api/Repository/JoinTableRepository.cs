using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class JoinTableRepository : IJoinTableRepository
    {
        private readonly ApplicationDBContext _context;
        public JoinTableRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<List<Stock>> GetUserJoinTables(AppUser user)
        {
            return await _context.JoinTables.Where(x => x.AppUserId == user.Id).Select(stock => new Stock{
                Id = stock.StockId,
                Symbol = stock.Stock.Symbol,
                CompanyName = stock.Stock.CompanyName,
                Purchase = stock.Stock.Purchase,
                LastDiv = stock.Stock.LastDiv,
                Industry = stock.Stock.Industry,
                MarketCap = stock.Stock.MarketCap,
                Comments = stock.Stock.Comments
            }).ToListAsync();
        }

        public async Task<JoinTable> CreateAsync(JoinTable joinTable)
        {
            await _context.JoinTables.AddAsync(joinTable);
            await _context.SaveChangesAsync();
            return joinTable;
        }

        public async Task<JoinTable> DeleteJoinTable(AppUser appUser, string symbol)
        {
            var joinTableModel = await _context.JoinTables.FirstOrDefaultAsync(x => x.AppUserId == appUser.Id && x.Stock.Symbol.ToLower() == symbol.ToLower());
            if(joinTableModel == null) return null;
            _context.JoinTables.Remove(joinTableModel);
            await _context.SaveChangesAsync();
            return joinTableModel;
        }
    }
}