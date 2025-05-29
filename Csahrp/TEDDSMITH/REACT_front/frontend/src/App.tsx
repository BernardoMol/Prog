import React, { useEffect, useState } from 'react';
import logo from './logo.svg';
import './App.css';
import Cartao from './Componentes/Cartoes/Cartao';
import ListaCartoes from './Componentes/ListaCartoes/ListaCartoes';
import { buscarTodasReclamacoes } from './api';
import { Reclamacao } from './TiposDeDados';


function App() {

  //Crie um estado para armazenar as reclamações
  const [reclamacoes, setReclamacoes] = useState<Reclamacao[]>([]);


  useEffect(() => {
    (async () => {
      const dados = await buscarTodasReclamacoes()
      console.log("TO BSUCANDO DADOOOS" , dados)
      setReclamacoes(dados)
    })();
  },[])

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
