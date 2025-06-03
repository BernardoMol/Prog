using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace bibliotecaReclamao.Banco.Modelos
{
    public class Usuario : IdentityUser<int>
    {
        [Key]
        public int UsuarioId { get; set; }
        // public string NomeUsuario { get; set; }
        public string? ImagemUsuario { get; set; }
        // public string EmailUsuario { get; set; }
        // public string SenhaUsuario { get; set; }

        // Propriedade de navegação para representar a coleção de Reclamacoes
        public ICollection<Reclamacao>? Reclamacoes { get; set; } 

    }
}