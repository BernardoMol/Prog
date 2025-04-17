using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;



partial class Program
{
    static void CriarArquivo()
    {
        var caminhoNovoArquivo = "contasExportadas.csv";
        using(var fluxoArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
        {
            var contaComoString = "456,78945,4785.50,Gustavo Santos";
            var encoding = Encoding.UTF8;
            var bytes = encoding.GetBytes(contaComoString);
            
            fluxoArquivo.Write(bytes, 0, bytes.Length);
            
            var buffer = new byte[1024];
            var numeroDeBytesLidos = -1; 
            

            while (numeroDeBytesLidos != 0)
            {
                numeroDeBytesLidos = fluxoArquivo.Read(buffer, 0, 1024); // 0 zero até 1024
                ExibeBuffer(buffer, numeroDeBytesLidos);
            }
            fluxoArquivo.Close();
        }
    }

    static void CriarArquivoComWriter()
    {
        var caminhoNovoArquivo = "contasExportadasWriter.csv";
        using(var fluxoArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
        // using(var fluxoArquivo = new FileStream(caminhoNovoArquivo, FileMode.CreateNew)) // se o arquivo ja existir, ele da erro
        using(var escritor = new StreamWriter(fluxoArquivo, Encoding.UTF8))
        {
            escritor.Write("456,65465,456.0,Pedro");
        }
    }

    static void TestaEscrito()
    {
        var caminhoNovoArquivo = "TESTE.txt";
        using(var fluxoArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
        // using(var fluxoArquivo = new FileStream(caminhoNovoArquivo, FileMode.CreateNew)) // se o arquivo ja existir, ele da erro
        using(var escritor = new StreamWriter(fluxoArquivo, Encoding.UTF8))
        {
            // escritor.WriteLine("Linha 0");
            // Console.ReadLine();
            // escritor.WriteLine("Linha 1");
            // Console.ReadLine();
            // escritor.WriteLine("Linha 2");
            // Console.ReadLine();
            // escritor.WriteLine("Linha 3");
            // Console.ReadLine();
            // escritor.WriteLine("Linha 4");
            // Console.ReadLine();
            // o conteudo só é escrito quando saio da aplicação
            // o processo de escrita no HD demora, ´por isso, demora pra escrever
            // usamos o buffer do streamwriter para escrever de forma mais eficiente
            // enquanto nao paramos de usar este buffer do streamwriter, ele nao escreve no arquivo (a informação não é despejada filestream)
            // para evitar de usar esse buffer, usamos o FLUSH
            escritor.WriteLine("Linha 5");
            escritor.WriteLine("Linha 6");
            escritor.WriteLine("Linha 7");
            escritor.Flush(); // força a escrita do buffer
            Console.ReadLine(); 
        }
    }
}
