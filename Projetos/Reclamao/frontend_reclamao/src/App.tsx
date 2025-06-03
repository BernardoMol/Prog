import React from 'react';
import logo from './logo.svg';
import './App.css';

import { Routes, Route } from 'react-router-dom';
import Login from './Paginas/Login';
import Usuario from './Paginas/Usuario';
import NovaReclamacao from './Paginas/NovaReclamacao';


const Home = () => <h1>Página Inicial</h1>; // Página destino após login

function App() {
  return (
    <div className="App">
    <Routes>
      {/* <Route path="/" element={<LoginBasico />} /> */}
      <Route path="/" element={<Login />} />
      <Route path="/home" element={<Home />} />
      <Route path="/usuario" element={<Usuario />} />
      <Route path="/nova-reclamacao" element={<NovaReclamacao />} />
    </Routes>
    </div>
  );
}

export default App;
