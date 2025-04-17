

void titulo()
{
    Console.WriteLine("Jogo de Adivinhacao !!!");
}

void ExibirMenu()
{
    Random random = new Random();
    int numeroGeradoAleatoriamente = random.Next(1, 101); // Gera um número entre 1 e 100 
    bool respostaCerta = false;

    while (!respostaCerta)
    {
        Console.Write("\n Tente adivinhar o número MAGICO (entre 1 e 100): ");
        string chute = Console.ReadLine()!;

        if (int.TryParse(chute, out int chuteNumerico))
        {
            Console.WriteLine($"\nVocê escolheu a opção {chuteNumerico}");
            if (chuteNumerico > numeroGeradoAleatoriamente) {
                Console.WriteLine($"\n O número escolhido por você é MAIOR que o número MAGICO");
            }
            else if (chuteNumerico < numeroGeradoAleatoriamente) {
                Console.WriteLine($"\n O número escolhido por você é MENOR que o número MAGICO");
            }
            else
            {
                Console.WriteLine($"\n Parabéns !!! Você escolheu {chuteNumerico} e o número MAGICO é {numeroGeradoAleatoriamente}");
                respostaCerta = true;
            }
        }
        else
        {
            // Falha na conversão, exibe a mensagem de erro
            Console.WriteLine("\nA opção precisa ser um número....");
        }
    }
};

titulo();
ExibirMenu();