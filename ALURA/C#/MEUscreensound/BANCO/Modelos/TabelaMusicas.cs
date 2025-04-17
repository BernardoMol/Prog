using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScreenSound.BANCO.Modelos
{
     [Index(nameof(Nome), IsUnique = true)] // Define Nome como único
    public class TabelaMusicas
    {     
        [Key]
        public int Id {get; set;}
        [Required]
        public string Nome {get; set;} = string.Empty; // só pra n colocar nulo
        public string Artista { get; set; } = string.Empty;
    }
}