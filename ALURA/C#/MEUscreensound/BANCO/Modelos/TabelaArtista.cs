using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ScreenSound.BANCO.Modelos
{
    [Index(nameof(Nome), IsUnique = true)] // Define Nome como único
    public class TabelaArtista
    {
                
        [Key]
        public int Id {get; set;}
        [Required]
        public string Nome {get; set;} = string.Empty; // só pra n colocar nulo
        public string Bio {get; set;} = string.Empty;
        public byte[]? Foto { get; set; } = Array.Empty<byte>(); // A interrogação deixa opicional
        public string Genero { get; set; } = string.Empty;
        

        public byte[] ConverterImagemParaBytes(string caminhoArquivo)
        {
            return File.ReadAllBytes(caminhoArquivo);
        }
    }

}