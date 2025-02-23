using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos
{
    // DESNECESSÁRIO, CRIADO APENAS POR QUESTÕES DE ORGANIZAÇÃO
    public class NewUserDto
    {
        public string UserName { get; set; }   
        public string Email { get; set; }   
        public string Token { get; set; }   
    }
}