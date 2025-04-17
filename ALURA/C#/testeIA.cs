using OpenAI;
using OpenAI.Chat;
using System;
using System.Threading.Tasks;

namespace ScreenSound
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string nomeDaBanda = "Ira";
            string apiKey = "sk-proj-LXbV5pFp63Ks9we7I6AY_mlQCuDjsbSEI1NKrk9_6EZtDJ87d8KxloNGfuD_0QyQTuvQ_1gGRsT3BlbkFJ1m1LsKGDKtc_xATVjnukK_e1wLPZdGu6e35SMW6dsg4-G4h9Z9X7BmayhiebG_QFa8Kdem4MQAI";
            
            // Criando um cliente do Chat com a chave da API
            ChatClient client = new(model: "gpt-4", apiKey: apiKey);
            
            // Realizando a solicitação de completamento do chat
            var completion = await client.CompleteChatAsync($"Faça um resumo curto sobre a banda {nomeDaBanda}.");
            
            // Exibindo a resposta
            Console.WriteLine($"[ASSISTANT]: {completion.Content[0].Text}");
        }
    }
}