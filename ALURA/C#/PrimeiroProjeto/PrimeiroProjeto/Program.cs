//  Screen Sound
//  string mensagemBoasVindas = "Bem Vindo";
//  Console.WriteLine(mensagemBoasVindas);
using System;
//List<string> listaDasBandas = new List<String> {"U2", "Beattles" };
Dictionary<string, List<int>> dicionarioDeBands = new Dictionary<string, List<int>>();
dicionarioDeBands.Add("Link Park", new List<int> {10, 8, 6});
dicionarioDeBands.Add("Beattles", new List<int>());

void ExibirLogo()
{
       Console.WriteLine(@"
        ░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
        ██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
        ╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
        ░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
        ██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
        ╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
      ");
};

void ExibirMenu()
{
    ExibirLogo();
    Console.WriteLine("\n1 - Registrar Banda");
    Console.WriteLine("2 - Mostrar todas as Bandas");
    Console.WriteLine("3 - Avaliar Bandas");
    Console.WriteLine("4 - Consultar média da Banda");
    Console.WriteLine("5 - Sair");

    //Console.Write("\n Digite a opção: ");
    //string opcao = Console.ReadLine()!;
    //int opcaoNumerica = int.Parse(opcao);


    bool entradaValida = false;
    while (!entradaValida)
    {
        Console.Write("\n Digite a opção: ");
        string opcao = Console.ReadLine()!;

        if (int.TryParse(opcao, out int opcaoNumerica))
        {
            Console.WriteLine($"\nVocê escolheu a opção {opcaoNumerica}");
            entradaValida = true;
            switch (opcaoNumerica)
            {
                case 1:
                    Console.Write("\n Opção escolhida: " + opcaoNumerica + "\n");
                    RegistrandoBandas();
                    break;
                case 2:
                    Console.Write("\n Opção escolhida: " + opcaoNumerica + "\n");
                    ExibirBandas();
                    break;
                case 3:
                    Console.Write("\n Opção escolhida: " + opcaoNumerica + "\n");
                    AvaliarBandas();
                    break;
                case 4:
                    Console.Write("\n Verificar MÉDIA da banda \n");
                    ExibirMedia();
                    break;
                case 5:
                    Console.Write("\n Opção escolhida: SAIR \n");
                    break;
                default:
                    Console.Write("\n Opção INVALIDA \n");
                    break;
            }
        }
        else
        {
            // Falha na conversão, exibe a mensagem de erro
            Console.WriteLine("\nA opção precisa ser um número.");
        }
    }
};

void RegistrandoBandas()
{
    Console.Clear();
    MontandoTituloDaOpcao("Registro De Bandas");
    //Console.WriteLine("Registro de bandas");
    Console.Write("Digite o nome da banda: ");
    string nomeDaBanda = Console.ReadLine()!;
    //listaDasBandas.Add(nomeDaBanda);
    dicionarioDeBands.Add(nomeDaBanda, new List<int>());
    Console.Write($"A banda: {nomeDaBanda} foi registrada com sucesso");
    Thread.Sleep(2000);
    Console.Clear();
    ExibirMenu();
}
void ExibirBandas(){
    Console.Clear();
    //Console.WriteLine("EXIBINDO BANDAS: ");
    //for (int i=0; i<listaDasBandas.Count; i++)
    //{
    //    Console.WriteLine(listaDasBandas[i]);
    //}
    MontandoTituloDaOpcao("Exibindo Bandas");
    //foreach (string banda in listaDasBandas)
    //{
    //    Console.WriteLine(banda);
    //}
    foreach (string banda in dicionarioDeBands.Keys)
    {
        Console.WriteLine(banda);
    }

    Console.WriteLine("\n Digite qualquer tecla para retornar ao menu inicial");
    Console.ReadKey();
    Console.Clear();
    ExibirMenu();


}
void AvaliarBandas(){
    Console.Clear();
    MontandoTituloDaOpcao("Avaliando Banda");
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeDaBandaAvaliada = Console.ReadLine()!;
    if (dicionarioDeBands.ContainsKey(nomeDaBandaAvaliada))
    {
        bool notaNumero = false;
        while (!notaNumero){
            Console.Write($"\n Qual nota voce da para a banda {nomeDaBandaAvaliada}: ");
            string nota = Console.ReadLine();
            if (int.TryParse(nota, out int notaNumerica))
            {
                dicionarioDeBands[nomeDaBandaAvaliada].Add(notaNumerica);
                Console.WriteLine("\n Nota registrada com sucesso");
                notaNumero = true;
                Thread.Sleep(1500);
                Console.Clear();
                ExibirMenu();
            }
            else
            {
                // Falha na conversão, exibe a mensagem de erro
                Console.WriteLine("\nA opção precisa ser um número.");
            }
        }
    }
    else
    {
        Console.WriteLine($"\n Banda {nomeDaBandaAvaliada} não encontrada, verifique o nome");
        Console.WriteLine($"Digite uma tecla para voltar para o menu inicial");
        Console.ReadKey();
        Console.Clear();
        ExibirMenu();
    }
}
void ExibirMedia()
{
    Console.Clear();
    MontandoTituloDaOpcao("Exibindo Média da Banda");
    Console.Write("Digite o nome da banda para ver sua média: ");
    string nomeDaBandaAvaliada = Console.ReadLine()!;
    if (dicionarioDeBands.ContainsKey(nomeDaBandaAvaliada))
    {
        Console.WriteLine("As notas da banda são:");
        foreach (int nota in dicionarioDeBands[nomeDaBandaAvaliada])
        {
            // Exibindo nota por nota
            Console.WriteLine($"- {nota}");
        }
        List<int> notasDaBandaEscolhida = dicionarioDeBands[nomeDaBandaAvaliada];
        double mediaBanda = notasDaBandaEscolhida.Average();
        Console.WriteLine($"\n Então a média da banda {nomeDaBandaAvaliada} é {mediaBanda}");
        Thread.Sleep(2000);
        Console.Clear();
        ExibirMenu();

    }
    else
    {
        Console.WriteLine($"\n Banda {nomeDaBandaAvaliada} não encontrada, verifique o nome");
        Console.WriteLine($"Digite uma tecla para voltar para o menu inicial");
        Console.ReadKey();
        Console.Clear();
        ExibirMenu();
    }

}
void MontandoTituloDaOpcao(string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*'); // aqui tem q ser aspas simples pq é so 1 caracter
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}


ExibirMenu();



////  DICIONARIOS COMPLEXOS
//var notasAlunos = new Dictionary<string, Dictionary<string, List<int>>> {
//    { "Ana", new Dictionary<string, List<int>> {
//        { "C#", new List<int> { 8, 7, 6 } },
//        { "Java", new List<int> { 7, 6, 5 } },
//        { "Python", new List<int> { 9, 8, 8 } }
//    }},
//    { "Maria", new Dictionary<string, List<int>> {
//        { "C#", new List<int> { 6, 5, 4 } },
//        { "Java", new List<int> { 8, 7, 6 } },
//        { "Python", new List<int> { 6, 10, 5 } }
//    }},
//    { "Luiza", new Dictionary<string, List<int>> {
//        { "C#", new List<int> { 2, 3, 10 } },
//        { "Java", new List<int> { 8, 8, 8 } },
//        { "Python", new List<int> { 7, 7, 7 } }
//    }}
//};

////  ACESSANDO DICIONARIOS COMPLEXOS
//List<int> notasPythonMaria = notasAlunos["Maria"]["Python"];
//double mediaMariaEmPython = notasPythonMaria.Average();
//Console.WriteLine(mediaMariaEmPython);
