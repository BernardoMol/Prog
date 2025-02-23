using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.models;

namespace api.Interfaces
{
    public interface IJoinTableRepository
    {
        Task<List<Stock>> GetUserJoinTables(AppUser user);
        Task<JoinTable> CreateAsync(JoinTable joinTable); 
         Task<JoinTable> DeleteJoinTable(AppUser appUser, string symbol);
    }
} 