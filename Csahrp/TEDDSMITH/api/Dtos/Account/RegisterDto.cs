using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Account
{
    public class RegisterDto
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        [EmailAddress] // DOIDERA, só essa linha de codigo já verifica se o email é valido
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}