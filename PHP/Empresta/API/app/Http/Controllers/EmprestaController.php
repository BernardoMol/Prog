<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;

class EmprestaController extends Controller
{


    public function listarInstituicoes()
    {
        $data = $this->getJsonData('instituicoes.json');
        if (is_null($data)) {
            return response()->json(['error' => 'Arquivo não encontrado'], 404);
        }

        return response()->json($data);
    }

    public function listarConvenios()
    {
        $data = $this->getJsonData('convenios.json');
        if (is_null($data)) {
            return response()->json(['error' => 'Arquivo não encontrado'], 404);
        }

        return response()->json($data);
    }


    public function realizarSimulacao(Request $request)
    {
        
        // Body POSTMAN
        // {
        //     "valor_emprestimo": 10000,
        //     "instituicoes": ["BMG", "PAN"],
        //     "convenios": ["INSS"],
        //     "parcela": 72
        // }
        
        // verificando se os dados tao no formato correto, se n, da erro
        $validated = $request->validate([
            'valor_emprestimo' => 'required|numeric',
            'instituicoes' => 'array',
            'convenios' => 'array',
            'parcela' => 'numeric|nullable'
        ]);

        // estando tudo validado, pego os dados
        // mesmo que o ususario nao espeficique instituição eu preciso pegar, ela so n faz parte do filtro
        $convenios = $this->getJsonData('convenios.json');
        $instituicoes = $this->getJsonData('instituicoes.json');
        $taxas = $this->getJsonData('taxas_instituicoes.json');

        // garanto que todos os arquivos que eu preciso foram carregados
        if (is_null($convenios) || is_null($instituicoes) || is_null($taxas)) {
            return response()->json(['error' => 'Arquivo de dados não encontrado'], 404);
        }

        // Verificando se os dados de entrada condizem com o que possuimos
        // Se nossos modelos de taxas compreendem a quantidade de parcelas
        if (!empty($validated['parcela'])) {
            $parcelasValidas = array_unique(array_column($taxas, 'parcelas'));
            sort($parcelasValidas); //ordenando
            if (!in_array($validated['parcela'], $parcelasValidas)) {
                $parcelasDisponiveis = implode(', ', $parcelasValidas);
                return response()->json([
                    'erro' => "Não encontramos simulações para {$validated['parcela']} parcelas. As opções de parcelamento disponíveis são: {$parcelasDisponiveis}."
                ], 400);
            }
        }

        // Se temos parceria com a instituição mencionada
        if (!empty($validated['instituicoes'])) {
            $instituicoesValidas = array_unique(array_column($taxas, 'instituicao'));
            foreach ($validated['instituicoes'] as $inst) {
                if (!in_array($inst, $instituicoesValidas)) {
                    // $instituicoesDisponiveis = json_encode($instituicoesValidas); // não saiu como o esperado kkk melhor formatar de outra forma
                    $instituicoesDisponiveis = implode(', ',$instituicoesValidas);
                    return response()->json([
                        'erro' => "Instituição '{$inst}' não encontrada. Instituições disponíveis: {$instituicoesDisponiveis}"
                    ], 400);
                }
            }
        }

        // Se temos parceria com o convenio mencionado
        if (!empty($validated['convenios'])) {
            $conveniosValidos = array_unique(array_column($taxas, 'convenio'));
            foreach ($validated['convenios'] as $conv) {
                if (!in_array($conv, $conveniosValidos)) {
                    $conveniosDisponiveis = implode(', ', $conveniosValidos);
                    return response()->json([
                        'erro' => "Convênio '{$conv}' não encontrado. Convênios disponíveis: {$conveniosDisponiveis}."
                    ], 400);
                }
            }
        }

        $simulacoes = [];

        foreach ($taxas as $tx) {
            if (!empty($validated['instituicoes']) && !in_array($tx['instituicao'], $validated['instituicoes'])) {
                continue;
            }

            if (!empty($validated['convenios']) && !in_array($tx['convenio'], $validated['convenios'])) {
                continue;
            }

            if (!empty($validated['parcela']) && $tx['parcelas'] != $validated['parcela']) {
                continue;
            }

            $valorParcela = $validated['valor_emprestimo'] * $tx['coeficiente'];
            // $valorTotal = $valorParcela * $tx['parcelas']; // so vi que n precisava depois

            $simulacoes[$tx['instituicao']][] = [
                'taxa' => $tx['taxaJuros'],
                'parcela' => $tx['parcelas'],
                'valor_parcela' => round($valorParcela, 2),
                'convenio' => $tx['convenio'],
                // 'instituicao' => $entrada['instituicao'], // fiquei com dó de tirar
                // 'valor_total' => round($valorTotal, 2), // fiquei com dó de tirar
            ];
        }

        return response()->json($simulacoes);
    }


    private function getJsonData(string $filename)
    {
        $filePath = base_path("../Dados/{$filename}");
        if (!file_exists($filePath)) {
            return null;
        }
        return json_decode(file_get_contents($filePath), true);
    }

}