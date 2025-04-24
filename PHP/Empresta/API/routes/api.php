<?php

use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;
use App\Http\Controllers\EmprestaController;



Route::get('/Empresta/Convenios', [EmprestaController::class, 'listarConvenios']);
Route::get('/Empresta/Instituicoes', [EmprestaController::class, 'listarInstituicoes']);
Route::post('/Empresta/Simulacao', [EmprestaController::class, 'realizarSimulacao']);


// Route::get('/Empresta/Convenios', function () {
//     $filePath = realpath(__DIR__ . '/../../DADOS/convenios.json'); // caminho do arquivo
//     if (!file_exists($filePath)) {
//         return response()->json(['error' => 'Arquivo não encontrado'], 404); // se o arquivo n existir avisa o erro
//     }
//     $data = json_decode(file_get_contents($filePath), true); // pego os dados do arquvivo

//     return response()->json($data); // passo os dados
// });

// Route::get('/Empresta/Instituicoes', function () {
//     $filePath = realpath(__DIR__ . '/../../DADOS/instituicoes.json');
//     if (!file_exists($filePath)) {
//         return response()->json(['error' => 'Arquivo não encontrado'], 404);
//     }
//     $data = json_decode(file_get_contents($filePath), true);

//     return response()->json($data);
// });

// Route::get('/user', function (Request $request) {
//     return $request->user();
// })->middleware('auth:sanctum'); // Este final, do middleware verifica se o ususario esta logado. entao nao vamos usar


// Route::post('/Empresta/Simulacao', function (Request $request) {
//     // Validação dos parâmetros
//     $validated = $request->validate([
//         'valor_emprestimo' => 'required|numeric',
//         'instituicoes' => 'array',
//         'convenios' => 'array',
//         'parcela' => 'numeric|nullable'
//     ]);

//     // Carregar arquivos
//     $instituicoesPath = realpath(__DIR__ . '/../../DADOS/instituicoes.json');
//     $conveniosPath = realpath(__DIR__ . '/../../DADOS/convenios.json');
//     $taxasPath = realpath(__DIR__ . '/../../DADOS/taxas_instituicoes.json');

//     if (!file_exists($instituicoesPath) || !file_exists($conveniosPath) || !file_exists($taxasPath)) {
//         return response()->json(['error' => 'Arquivo de dados não encontrado'], 404);
//     }

//     $instituicoesData = json_decode(file_get_contents($instituicoesPath), true);
//     $conveniosData = json_decode(file_get_contents($conveniosPath), true);
//     $taxasData = json_decode(file_get_contents($taxasPath), true);

//     $simulacoes = [];

//     foreach ($taxasData as $entrada) {
//         // Filtro por instituição
//         if (!empty($validated['instituicoes']) && !in_array($entrada['instituicao'], $validated['instituicoes'])) {
//             continue;
//         }

//         // Filtro por convênio
//         if (!empty($validated['convenios']) && !in_array($entrada['convenio'], $validated['convenios'])) {
//             continue;
//         }

//         // Filtro por parcela
//         if (!empty($validated['parcela']) && $entrada['parcelas'] != $validated['parcela']) {
//             continue;
//         }

//         // Cálculo do valor da parcela e total
//         $valorParcela = $validated['valor_emprestimo'] * $entrada['coeficiente'];
//         $valorTotal = $valorParcela * $entrada['parcelas'];

//         $simulacoes[] = [
//             'instituicao' => $entrada['instituicao'],
//             'convenio' => $entrada['convenio'],
//             'parcela' => $entrada['parcelas'],
//             'taxa' => $entrada['taxaJuros'],
//             'valor_parcela' => round($valorParcela, 2),
//             'valor_total' => round($valorTotal, 2),
//         ];
//     }

//     return response()->json($simulacoes);
// });
