using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using ByteBankIO;

partial class Program
{
    static void Main(string[] args)
    {
        var pathArquivo = "contas.txt";
        using(var fluxoArquivo = new FileStream(pathArquivo, FileMode.Open))
        {
            var leitor = new StreamReader(fluxoArquivo);
            //var linha = leitor.ReadLine(); // SE NAO DEFINI NADA, VAI ME DAR A PRIMEIRA LINHA DO ARQUIVO
            //var textoCompleto = leitor.ReadToEnd(); // carrega de uma unica vez, pode dar B.O. se o arquivo for muito grande
            int numero = leitor.Read(); // le um caractere por vez // se nao comentar o read to end da ruim, pq ele ja percorreu o arquivo
            // Console.WriteLine(linha);
            // Console.WriteLine(textoCompleto);
            Console.WriteLine(numero);

            while (!leitor.EndOfStream) // exibe o conteudo de forma cadenciada
            {
                var linhaAtual = leitor.ReadLine();
                // Console.WriteLine(linhaAtual);
                // converterParaResultado(linhaAtual);
                // Console.WriteLine("Fim");
                var contaCorrente = converterParaResultado(linhaAtual);
                //Console.WriteLine(contaCorrente.Numero);
            }
            // Console.WriteLine("Criando arquivo");
            // CriarArquivo();
            // CriarArquivoComWriter();
            // TestaEscrito();

        }

        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
            var caminhoNovoArquivo = "testaEscritaBinaria.csv";
            using(var fluxoArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
            using(var escritor = new StreamWriter(fluxoArquivo, Encoding.UTF8))
            {
                escritor.WriteLine(true);
                escritor.WriteLine(false);
                escritor.WriteLine(434343434343);
            }
            Console.WriteLine("Aplicação Finalizada.");
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================

        //EscritaBinaria();   // no arquivo, fica cagado, porque ele escreve em binário e nao temos representaçõs suficientes.
        //LeituraBinaria(); // mesmo que no arquivo esteja cagado, da pra ler por aqui
        // UsarStringDeEntrada();

        //=======================================================================================================
        //==================FORMA SIMPLIFICADA DE LIDAR COM OS ARQUIVOS==========================================
        //=======================================================================================================

        Console.WriteLine("Digite seu nome.");
        var nome = Console.ReadLine();

        var linhas = File.ReadAllLines("contas.txt");
        Console.WriteLine(linhas.Length);

        foreach (var linha in linhas)
        {
            Console.WriteLine(linha);
        }

        var bytesArquivo = File.ReadAllBytes("contas.txt");
        Console.WriteLine(bytesArquivo.Length);
        File.WriteAllText("escrevendoComWriteAllText.txt", "Linha 1\nLinha 2\nLinha 3\nLinha 4");


        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================


        Console.ReadLine();
    }

    static ContaCorrente converterParaResultado(string linha)
    {
        // 375 4644 283.13 Jonathan
        if (string.IsNullOrWhiteSpace(linha)) 
        {
            throw new FormatException("Linha vazia ou inválida detectada no arquivo.");
        }
        // Console.WriteLine(linha);

        
        var campos = linha.Split(',');
        // Console.WriteLine(campos.Length);
        var agencia = campos[0];
        var conta = campos[1]; 
        var saldo = campos[2].Replace('.', ',');   
        var nomeCliente = string.Join(" ", campos.Skip(3));

        if (campos.Length < 4)
        {   
            throw new FormatException($"Linha inválida: '{linha}'. Esperado: [agência] [conta] [saldo] [nome].");
        }   

        var titular = new Cliente();
        titular.Nome = nomeCliente;

        var resultado = new ContaCorrente(int.Parse(agencia), int.Parse(conta));
        resultado.Depositar(double.Parse(saldo));
        resultado.Titular = titular;     

        return resultado;
    }
    
}