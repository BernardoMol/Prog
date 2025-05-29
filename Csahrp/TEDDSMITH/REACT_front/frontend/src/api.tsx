// var apiURL = "http://minha-api-reclamacao.onrender.com/Reclamacao/Reclamacao";
// using (HttpClient client = new HttpClient())
// {
//     Console.Write("vou passar para a variavel");
//     HttpResponseMessage response = await client.GetAsync(apiURL);
//     string jsonResponse = await response.Content.ReadAsStringAsync();
//     Console.Write("passei");
//     Console.Write(jsonResponse);
// }


//  Posso colocar aqui
// export interface Reclamacao {
//   id: number;
//   conteudo: string;
//   imagem: string | null; // Pode ser string ou null, como no seu modelo C#
// }

// ou aqui (MAS É DENSNECESSRIOP PORQUE JA ESTOU RECEBENDO O ARRAY JSON QUE QUERO)
// import { Reclamacao } from "./TiposDeDados";
// interface RespostaBuscaTodos{
//     dados: Reclamacao[];
// }


import { Reclamacao } from "./TiposDeDados";

const API_BASE_URL = "https://minha-api-reclamacao.onrender.com/Reclamacao/Reclamacao";

export const buscarTodasReclamacoes = async () => {
  try {

    console.log(`Buscando todas as reclamações de: RECLAMAO`);
    const response = await fetch(API_BASE_URL); // BUSCANDO TODOS OS DADOS

    if (!response.ok) {// verifica se deu bom
      const errorText = await response.text(); // le o erro
      throw new Error(`Erro HTTP! Status: ${response.status}. Mensagem: ${errorText}`);
    }

    // Converte a resposta JSON para um objeto JavaScript/TypeScript
    const dados: Reclamacao[] = await response.json();
    return dados;

  } catch (error) {
    console.error("Erro ao buscar todas as reclamações:", error);
    throw error; // Relança o erro para que o componente que chamou possa tratá-lo
  }
};