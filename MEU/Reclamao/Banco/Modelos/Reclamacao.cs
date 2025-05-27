using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reclamao.Banco.Modelos
{
    public class Reclamacao
    {
        public int Id { get; set; }
        public string Conteudo { get; set; }
        public string? Imagem { get; set; }
    }
}