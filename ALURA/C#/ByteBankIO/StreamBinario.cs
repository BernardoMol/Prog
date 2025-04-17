using System.Text;

partial class Program
{
    static void EscritaBinaria()
    {
        using (var fs = new FileStream("contaCorrenteBINARIO.txt", FileMode.Create))
        using (var escritor = new BinaryWriter(fs))
        {
            escritor.Write(456);             // número da Agência
            escritor.Write(546544);          // número da conta
            escritor.Write(4000.50);         // Saldo
            escritor.Write("Gustavo Braga"); // nao usa writwe line pq estamos escrevendo de forma binária.
        }
    }

    static void LeituraBinaria()
    {
        using (var fs = new FileStream("contaCorrenteBINARIO.txt", FileMode.Open))
        using (var leitor = new BinaryReader(fs))
        {
            var agencia = leitor.ReadInt32(); // o "32" é porque a representação esta em 32 bits
            var numero = leitor.ReadInt32();
            var saldo = leitor.ReadDouble(); // nao usamos parse porque estamos lendo de forma binária
            var titular = leitor.ReadString();
            System.Console.WriteLine($"Agência: {agencia}, Número: {numero}, Saldo: {saldo}, Titular: {titular}");
        }
    }
}
