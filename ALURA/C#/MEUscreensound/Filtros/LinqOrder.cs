using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScreenSound.Modelos;

namespace ScreenSound.Filtros
{
    public class LinqOrder
    {
        public static void OrdenarPorArtista(List<MusicaModeladaAPI> listaDeMusicas)
        {
            var artistasOrdenados = listaDeMusicas.OrderBy(musica => musica.Artista).Select(musica => musica.Artista).Distinct().ToList();
            Console.WriteLine($"\n LISTA DE ARTISTAS ORDENADA");
            foreach (var artista in artistasOrdenados)
            {
                Console.WriteLine($"--> {artista}");
            }
        }
    }
}