using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using ScreenSound.Modelos;
namespace ScreenSound.Filtros
{
    public class LinqFilter
    {
        public static void FiltrarGeneros(List<MusicaModeladaAPI> listaDeMusicas)
        {
            var listaDeGeneros = listaDeMusicas.Select(generos => generos.Genero).Distinct().ToList();
            foreach (var genero in listaDeGeneros)
            {
                Console.WriteLine($"--> {genero}");
            }
        }

        public static void FiltrarArtistasPorGeneros(List<MusicaModeladaAPI> listaDeMusicas, string genero) 
        {
            var artistasPorGeneroMusical = listaDeMusicas.Where(musica => musica.Genero.Contains(genero)).Select(musica => musica.Artista).Distinct().ToList();
            Console.WriteLine($"LISTA DE ARTISDAS POR GENERO MUSICAL = {genero}");
            foreach (var artistasGenero in artistasPorGeneroMusical)
            {
                Console.WriteLine($"--> {artistasGenero}");
            }
        }

        public static void FiltrarMusicasDoArtista(List<MusicaModeladaAPI> listaDeMusicas, string nomeArtista) // aqui a gent pega o artista e tido q tem nele, por isso o WHERE
        {
            var musicasArtista = listaDeMusicas.Where(musica => musica.Artista!.Equals(nomeArtista)).Distinct().ToList(); // como é string usamops o EQUALS e n "=="
            Console.WriteLine($"\nMUSICAS DO ARTISTA = {nomeArtista}");
            foreach (var musica in musicasArtista)
            {
                Console.WriteLine($"--> {musica.Nome}");
            }
        }

        public static void FiltrarMusicasTonalidade(List<MusicaModeladaAPI> listaDeMusicas, string ton) // aqui a gent pega o artista e tido q tem nele, por isso o WHERE
        {
            var musicasTonalidade = listaDeMusicas.Where(musicaT => musicaT.Ton!.Equals(ton)).Distinct().ToList(); // como é string usamops o EQUALS e n "=="
            Console.WriteLine($"\nMUSICAS COM TONALIDADE = {ton}");
            foreach (var musica in musicasTonalidade)
            {
                Console.WriteLine($"--> {musica.Nome}");
            }
        }
    }
}