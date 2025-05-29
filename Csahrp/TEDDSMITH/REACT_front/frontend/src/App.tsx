import React, { useState } from 'react';
import logo from './logo.svg';
import './App.css';
import Cartao from './Componentes/Cartoes/Cartao';
import ListaCartoes from './Componentes/ListaCartoes/ListaCartoes';
import { buscarTodasReclamacoes } from './api';
import { Reclamacao } from './TiposDeDados';


function App() {

  // 1. Crie um estado para armazenar as reclamações
  const [reclamacoes, setReclamacoes] = useState<Reclamacao[]>([]);
  // 2. Crie estados para o controle de carregamento da PÁGINA e erros
  // const [loading, setLoading] = useState<boolean>(true); 
  // const [error, setError] = useState<string | null>(null);

  (async () => {
    const dados = await buscarTodasReclamacoes()
    console.log("TO BSUCANDO DADOOOS" , dados)
    setReclamacoes(dados)
    // setLoading(false); // Indica que o carregamento terminou
  })();


  return (
    <>
      <div>
        <h1  className='TituloAPP'> Reclamão </h1>
      </div>
      <div className="App"> 
        <div>
          <ListaCartoes reclamacoes = {reclamacoes}/>
        </div>
      </div>
    </>
  );
}

export default App;
