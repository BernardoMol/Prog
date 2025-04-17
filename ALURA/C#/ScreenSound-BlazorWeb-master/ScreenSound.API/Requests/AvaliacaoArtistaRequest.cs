using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScreenSound.API.Requests
{
    public class AvaliacaoArtistaRequest
    {
        public int ArtistaId { get; set; }
        public int Nota { get; set; }
    }
}