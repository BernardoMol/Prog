using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos;
using api.Helpers;
using api.models;
using api.Repository;

namespace api.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync(QueryObject query);
        Task<Stock?> GetByIdAsync(int id); // a "?" esta aí porque o firstordefault pode ser nulo
        Task<Stock> GetBySymbolAsync(string symbol);
        Task<Stock> CreateAsync(Stock stockModel);
        Task<Stock> UpdateAsync(int id, UpdateStockRequestDto stockDto);
        Task<Stock> DeleteAsync(int id);
        Task<bool> StockExtists(int id);
        
    }
}