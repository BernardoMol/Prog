using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace ScreenSound.Modelos
{
    public class MusicaModeladaAPI
    {
        [JsonPropertyName("song")]
        public string? Nome {set;get;}
        [JsonPropertyName("artist")]
        public string? Artista {set;get;}
        [JsonPropertyName("duration_ms")]
        public int Duracao {set;get;}
        [JsonPropertyName("genre")]
        public string? Genero {set;get;}
        [JsonPropertyName("key")]
        public int Chave {set;get;}

        private string[] Tonalidades = {"C", "C#", "D", "Eb", "E", "F", "F#", "G", "Ab", "A", "Bb", "B"};

        public string Ton { 
            get
            {
                return Tonalidades[Chave];
            }

        }

        public void APIExibirDetalhesMusica()
        {
            Console.WriteLine($"\nNome: {Nome}");
            Console.WriteLine($"Artista: {Artista}");
            Console.WriteLine($"Duracao (segundos): {Duracao/1000}");
            Console.WriteLine($"Genero: {Genero}");
            Console.WriteLine($"Tonalidade da musica: {Ton}");
        }
    }

}