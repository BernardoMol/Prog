<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;

class EmprestaController extends Controller
{
    public function listarConvenios()
    {
        // $filePath = realpath(__DIR__ . '/../../../DADOS/convenios.json');
        $filePath = base_path('../Dados/convenios.json');
        if (!file_exists($filePath)) {
        return response()->json(['error' => 'Arquivo não encontrado'], 404); // se o arquivo n existir avisa o erro
        }
        $data = json_decode(file_get_contents($filePath), true); // pego os dados do arquvivo

        return response()->json($data); // passo os dados
    }

    public function listarInstituicoes()
    {
        $filePath = base_path('../Dados/instituicoes.json');
        if (!file_exists($filePath)) {
            return response()->json(['error' => 'Arquivo não encontrado'], 404);
        }
        $data = json_decode(file_get_contents($filePath), true);
    
        return response()->json($data);
    }

    public function realizarSimulacao(Request $request)
    {
        // return "Ainda Ouvindo";
       
        // Body POSTMAN
        // {
        //     "valor_emprestimo": 10000,
        //     "instituicoes": ["BMG", "PAN"],
        //     "convenios": ["INSS"],
        //     "parcela": 72
        // }
       
        // Validando os parametros do body do postman
        $validated = $request->validate([
            'valor_emprestimo' => 'required|numeric',
            'instituicoes' => 'array',
            'convenios' => 'array',
            'parcela' => 'numeric|nullable'
        ]);

        // Pega o Caminho dos arquivos
        $conveniosPath = base_path('../Dados/convenios.json');
        $instituicoesPath = base_path('../Dados/instituicoes.json');
        $taxasPath = base_path('../Dados/taxas_instituicoes.json');

        // Se algum dos arquivos não existir (ou caminho errado), acusa ERRO
        if (!file_exists($instituicoesPath) || !file_exists($conveniosPath) || !file_exists($taxasPath)) {
            return response()->json(['error' => 'Arquivo de dados não encontrado'], 404);
        }

        // Carrega os arquivos
        $instituicoesData = json_decode(file_get_contents($instituicoesPath), true);
        $conveniosData = json_decode(file_get_contents($conveniosPath), true);
        $taxasData = json_decode(file_get_contents($taxasPath), true);

        $simulacoes = [];

        // FILTRANDO
        foreach ($taxasData as $entrada) {
       //instituição
        if (!empty($validated['instituicoes']) && !in_array($entrada['instituicao'], $validated['instituicoes'])) {
            continue;
        }

        //convênio
        if (!empty($validated['convenios']) && !in_array($entrada['convenio'], $validated['convenios'])) {
            continue;
        }

        //parcela
        if (!empty($validated['parcela']) && $entrada['parcelas'] != $validated['parcela']) {
            continue;
        }

        // Calculando parcela e valor total
        $valorParcela = $validated['valor_emprestimo'] * $entrada['coeficiente'];
        $valorTotal = $valorParcela * $entrada['parcelas'];

        $simulacoes[] = [
            'instituicao' => $entrada['instituicao'],
            'convenio' => $entrada['convenio'],
            'parcela' => $entrada['parcelas'],
            'taxa' => $entrada['taxaJuros'],
            'valor_parcela' => round($valorParcela, 2),
            'valor_total' => round($valorTotal, 2),
            ];
        }

        return response()->json($simulacoes);
    }

}
