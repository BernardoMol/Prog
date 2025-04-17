using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace ScreenSound.Shared.Dados.Modelos
{
    public class PerfilDeAcesso : IdentityRole<int>
    {
        
    }
}