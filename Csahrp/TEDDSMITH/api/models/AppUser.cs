using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace api.models
{
    public class AppUser: IdentityUser
    {
        public List<JoinTable> JoinTables { get; set; } = new List<JoinTable>();
        // Não colocamos nada porque ele ja vem com o default
    }
}