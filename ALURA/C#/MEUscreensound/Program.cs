using ScreenSound.Menus;
using ScreenSound.Modelos;
using System.Text.Json.Serialization;
using System.Text.Json;
using ScreenSound.Filtros;
using System;
using ScreenSound.BANCO;
using ScreenSound.BANCO.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Runtime.InteropServices;


try
{
    // CRIANDO AS MIGRAÇÕES AUTOMATICAMENTE
    var gerarMigraçãoAutomatizada = new MigracaoAutomatizada();
    gerarMigraçãoAutomatizada.GerarMigracao();
    Console.WriteLine("Migrações geradas/verificadas com sucesso! \n");
    // APLICANDO AS MIGRAÇÕES (update)
    using (var contexto = new conexaoComBanco())
    {
        contexto.Database.Migrate(); // Aplica as migrations automaticamente
    }
    Console.WriteLine("Banco de dados atualizado com sucesso! \n");

    var connection = new conexaoComBanco();
    var ArtistaDAL = new ArtistaDAL(connection);
    
    // ADICIONANDO ARTISTA (com verificação de duplicidade por nome)
    // bool artistaExiste = ArtistaDAL.ObterArtistas().Any(a => a.Nome == "Foo Fighters"); // verifica se ja tem alguem com o nome foo fighters
    var artistaExistente = ArtistaDAL.ObterArtistas().FirstOrDefault(a => a.Nome == "Foo Fighters");

    if (artistaExistente == null) // Se não existir, insere
    {
        var artistaNovo = new TabelaArtista()
        {
            Nome = "Foo Fighters",
            Bio = "FF aparece em JOJO parte 6 !!!",
            Genero = "Rock",
            // Foto = Array.Empty<byte>() // ou use um caminho de arquivo se necessário
        };

        ArtistaDAL.AdicionarArtista(artistaNovo);
        artistaExistente = artistaNovo;
        Console.WriteLine("Artista Foo Fighters adicionado com sucesso! \n");
    }
    else
    {

        Console.WriteLine("O artista 'Foo Fighters' já existe no banco de dados. Nenhuma inserção foi feita. \n");
    }

    // LISTANDO ARTISTAS
    var listaDeArtistas = new List<TabelaArtista>();
    listaDeArtistas = ArtistaDAL.ObterArtistas().ToList();

    foreach (var artista in listaDeArtistas)
    {
        Console.WriteLine($"Id: {artista.Id}, Nome: {artista.Nome}, Bio: {artista.Bio}, Genero: {artista.Genero}");
    }

    // ATUALIZANDO ARTISTA
    artistaExistente.Genero = "Pop";
    ArtistaDAL.AtualizarArtista(artistaExistente);
    Console.WriteLine($"Artista atualizado: Id: {artistaExistente.Id}, Nome: {artistaExistente.Nome}, Bio: {artistaExistente.Bio}, Genero: {artistaExistente.Genero} \n");
    artistaExistente.Genero = "Rock";
    ArtistaDAL.AtualizarArtista(artistaExistente);

    // DELETANDO ARTISTA
    ArtistaDAL.DeletarArtista(artistaExistente);
    Console.WriteLine($"Artista deletado: Id: {artistaExistente.Id}, Nome: {artistaExistente.Nome}, Bio: {artistaExistente.Bio}, Genero: {artistaExistente.Genero} \n");
}
catch (Exception ex)
{
    Console.WriteLine($"Erro ao definir a codificação UTF-8: {ex.Message}");
}

return;


// try
// {
//     // isso ja roda o UPDATE, mas a criação e atribuição da migração aionda precisa ser feita
//     var gerarMigraçãoAutomatizada = new MigracaoAutomatizada();
//     gerarMigraçãoAutomatizada.GerarMigracao();
    
//     using (var contexto = new conexaoComBanco())
//         {
//             contexto.Database.Migrate(); // Aplica as migrations automaticamente
//         }
//     Console.WriteLine("Banco de dados atualizado com sucesso!");
// }
// catch (Exception ex)
// {
//     Console.WriteLine($"Erro ao definir a codificação UTF-8: {ex.Message}");
// }

// return;







using (HttpClient client = new HttpClient())
{
    try
    {
        string resposta = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
        // Console.WriteLine(resposta);
        var musicas = JsonSerializer.Deserialize<List<MusicaModeladaAPI>>(resposta)!;  // converter de JSON para o tipo que nossa linguagem entende
        // Console.WriteLine(musicas.Count);
        musicas[0].APIExibirDetalhesMusica();
        //LinqFilter.FiltrarGeneros(musicas);
        //LinqOrder.OrdenarPorArtista(musicas);
        //LinqFilter.FiltrarArtistasPorGeneros(musicas, "rock");
        //LinqFilter.FiltrarMusicasDoArtista(musicas, "Michel Teló");
        LinqFilter.FiltrarMusicasTonalidade(musicas,"C#");
        // var musicasPreferidasMol = new MusicasPreferidas("Mol");
        // musicasPreferidasMol.AddMusicasFavoritas(musicas[0]);
        // musicasPreferidasMol.AddMusicasFavoritas(musicas[1]);
        // musicasPreferidasMol.AddMusicasFavoritas(musicas[2]);
        // musicasPreferidasMol.AddMusicasFavoritas(musicas[3]);
        // musicasPreferidasMol.AddMusicasFavoritas(musicas[4]);

        // musicasPreferidasMol.ExibirMusicasFavoritas();


        // var musicasPreferidasGI= new MusicasPreferidas("GI");
        // musicasPreferidasGI.AddMusicasFavoritas(musicas[0]);
        // musicasPreferidasGI.AddMusicasFavoritas(musicas[11]);
        // musicasPreferidasGI.AddMusicasFavoritas(musicas[22]);
        // musicasPreferidasGI.AddMusicasFavoritas(musicas[33]);
        // musicasPreferidasGI.AddMusicasFavoritas(musicas[4]);

        // musicasPreferidasGI.ExibirMusicasFavoritas();

        // musicasPreferidasGI.GerarArquivoJson();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"\nOcorreu um erro: {ex.Message}");
    }
}



// FUNCIONANDO PERFEITAMENTE, MAS É OUTRO ESCOPO
// Banda ira = new Banda("Ira!");
// ira.AdicionarNota(new Avaliacao(10));
// ira.AdicionarNota(new Avaliacao(8));
// ira.AdicionarNota(new Avaliacao(6));
// Banda beatles = new("The Beatles");

// Dictionary<string, Banda> bandasRegistradas = new();
// bandasRegistradas.Add(ira.Nome, ira);
// bandasRegistradas.Add(beatles.Nome, beatles);

// Dictionary<int, Menu> opcoes = new();
// opcoes.Add(1, new MenuRegistrarBanda());
// opcoes.Add(2, new MenuRegistrarAlbum());
// opcoes.Add(3, new MenuMostrarBandas());
// opcoes.Add(4, new MenuAvaliarBanda());
// opcoes.Add(5, new MenuAvaliarAlbum());
// opcoes.Add(6, new MenuExibirDetalhes());
// opcoes.Add(-1, new MenuSair());

// void ExibirLogo()
// {
//     Console.WriteLine(@"

// ░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
// ██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
// ╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
// ░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
// ██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
// ╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
// ");
//     Console.WriteLine("Boas vindas ao Screen Sound 2.0!");
// }

// void ExibirOpcoesDoMenu()
// {
//     ExibirLogo();
//     Console.WriteLine("\nDigite 1 para registrar uma banda");
//     Console.WriteLine("Digite 2 para registrar o álbum de uma banda");
//     Console.WriteLine("Digite 3 para mostrar todas as bandas");
//     Console.WriteLine("Digite 4 para avaliar uma banda");
//     Console.WriteLine("Digite 5 para avaliar um álbum");
//     Console.WriteLine("Digite 6 para exibir os detalhes de uma banda");
//     Console.WriteLine("Digite -1 para sair");

//     Console.Write("\nDigite a sua opção: ");
//     string opcaoEscolhida = Console.ReadLine()!;
//     int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

//     if (opcoes.ContainsKey(opcaoEscolhidaNumerica))
//     {
//         Menu menuASerExibido = opcoes[opcaoEscolhidaNumerica];
//         menuASerExibido.Executar(bandasRegistradas);
//         if (opcaoEscolhidaNumerica > 0) ExibirOpcoesDoMenu();
//     } 
//     else
//     {
//         Console.WriteLine("Opção inválida");
//     }
// }


// ExibirOpcoesDoMenu();