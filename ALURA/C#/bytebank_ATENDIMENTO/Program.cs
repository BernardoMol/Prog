using bytebank_GeradorChavePix;
using System;
using Newtonsoft.Json;
using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Atendimento;
using bytebank_Modelos.bytebank.Modelos.ADM.Utilitario;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");
        // new ByteBankAtendimento().AtendimentoCliente();

        // using bytebank_GeradorChavePix;

        // Dentro de algum método no bytebank_ATENDIMENTO
        var chavePix = GeradorPix.GetChavePix();
        Console.WriteLine($"Chave Pix Gerada: {chavePix}");
    }
}