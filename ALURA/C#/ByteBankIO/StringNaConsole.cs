using System;
using System.IO;
using System.Text;

partial class Program
{
    static void UsarStringDeEntrada()
    {
        using (var fluxoDeEntrada = Console.OpenStandardInput())
        using (var fs = new FileStream("entradaConsole.txt", FileMode.Create))
        {
            var buffer = new byte[1024];
            var bytesLidos = fluxoDeEntrada.Read(buffer, 0, 1024);
            fs.Write(buffer, 0, bytesLidos);
            fs.Flush();
            //while (True)
            Console.WriteLine($"Bytes lidos da console: {bytesLidos}");
        }
    }
}
