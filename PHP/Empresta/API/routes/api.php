<?php

use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;
use App\Http\Controllers\EmprestaController;

Route::get('/Empresta/Instituicoes', [EmprestaController::class, 'listarInstituicoes']);
Route::get('/Empresta/Convenios', [EmprestaController::class, 'listarConvenios']);
Route::post('/Empresta/Simulacao', [EmprestaController::class, 'realizarSimulacao']);

