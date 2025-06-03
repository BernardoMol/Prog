import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import "./NovaReclamacao.css";

const NovaReclamacao: React.FC = () => {
  const [conteudo, setConteudo] = useState("");
  const navigate = useNavigate();

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    console.log("Reclamação enviada:", conteudo);
    setConteudo("");
    // Aqui você pode redirecionar após salvar, se quiser
  };

  const handleCancelar = () => {
    navigate("/usuario");
  };

  return (
    <div className="nova-reclamacao-container">
      <h1>Faça sua nova reclamação aqui !!!</h1>
      <form className="form-reclamacao" onSubmit={handleSubmit}>
        <textarea
          placeholder="Descreva sua reclamação..."
          value={conteudo}
          onChange={(e) => setConteudo(e.target.value)}
          required
        />
        <div className="botoes-form">
          <button type="submit">Enviar</button>
          <button type="button" onClick={handleCancelar} className="cancelar-btn">
            Cancelar
          </button>
        </div>
      </form>
    </div>
  );
};

export default NovaReclamacao;
