import React from 'react';
import logo from './logo.svg';
import './App.css';
import Cartao from './Componentes/Cartoes/Cartao';

function App() {
  return (
    <>
      <div>
        <h1  className='TituloAPP'> Reclamão </h1>
      </div>
      <div className="App"> 
        <div>
          <Cartao />
        </div>
        <div>
          <Cartao />
        </div>
        <div>
          <Cartao />
        </div>
        <div>
          <Cartao />
        </div>
      </div>
    </>
  );
}

export default App;
