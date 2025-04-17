using System;
using System.IO;
using System.Text;
using ByteBankIO;

partial class Program
{
    static void LidandoComFileStreamDiretamente(string[] args)
    {
        var pathArquivo = "contas.txt";
        using(var fluxoArquivo = new FileStream(pathArquivo, FileMode.Open))
        {
            var buffer = new byte[1024]; //1Kb
            var numeroDeBytesLidos = -1; // bytes nunca sao negativos, entao esse -1 nao interfere
            // fluxoArquivo.Read(buffer, 0, 1024); // 0 zero até 1024
            
            while (numeroDeBytesLidos != 0)
            {
                numeroDeBytesLidos = fluxoArquivo.Read(buffer, 0, 1024); // 0 zero até 1024
                ExibeBuffer(buffer, numeroDeBytesLidos);
            }
            fluxoArquivo.Close();
        }
        
    }

    static void ExibeBuffer(byte[] buffer, int bytesLidos)
    {
        var utf8 = new UTF8Encoding();
        // var texto = utf8.GetString(buffer);
        // public virtual string GetString(byte[] bytes, int index, int count)
        var texto = utf8.GetString(buffer, 0, bytesLidos);//agora so vai ler até o numero de bytes lidos
        Console.Write(texto);
        // foreach(var meuByte in buffer)
        // {
        //     Console.WriteLine(meuByte);
        //     Console.WriteLine("");
        // }
    }


    
}