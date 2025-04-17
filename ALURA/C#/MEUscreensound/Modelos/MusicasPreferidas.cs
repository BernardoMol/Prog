using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace ScreenSound.Modelos
{
    public class MusicasPreferidas
    {
        public string? Nome { get; set; }
        public List<MusicaModeladaAPI> ListaDeMusicasFavoritas {get;}

        public MusicasPreferidas(string nome){
            Nome = nome;
            ListaDeMusicasFavoritas = new List<MusicaModeladaAPI>();
        }

        public void AddMusicasFavoritas(MusicaModeladaAPI musica)
        {
            ListaDeMusicasFavoritas.Add(musica);
        }
        public void ExibirMusicasFavoritas()
        { 
            Console.WriteLine($"\nEstas são as musicas favoritas do {Nome}");
            foreach (var musica in ListaDeMusicasFavoritas)
            {
                Console.WriteLine($"--> {musica.Nome}");
            }
            Console.WriteLine();
        }
        public void GerarArquivoJson()
        { 
            string json = JsonSerializer.Serialize( new // Só ta o "new" sem nada, porque é um objeto anonimo, é uma erstrutura TEMPORÁRIA
            {
                nome = Nome,
                musicasDaLista = ListaDeMusicasFavoritas
            });
            string nomeArquivo = $"musicas-favoritas-{Nome}.json";
            File.WriteAllText(nomeArquivo,json);
            Console.WriteLine($"\nArquivo Criado Com Sucesso {Path.GetFullPath(nomeArquivo)}");
        }
    }
}