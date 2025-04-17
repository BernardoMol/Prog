using ScreenSound.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuMostrarArtistas : Menu
{
    public override void Executar(DAL<Artista> objetoArtsita)
    {
        base.Executar(objetoArtsita);
        ExibirTituloDaOpcao("Exibindo todos os artistas registradas na nossa aplicação");

        foreach (var artista in objetoArtsita.Listar())
        {
            Console.WriteLine($"Artista: {artista}");
        }

        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }
}
