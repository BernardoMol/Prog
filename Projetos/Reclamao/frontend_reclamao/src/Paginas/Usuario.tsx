import React from "react";
import { useNavigate } from "react-router-dom";
import "./Usuario.css";

const Usuario: React.FC = () => {
  const navigate = useNavigate();

  const imagemPerfil =
    "https://static.vecteezy.com/ti/vetor-gratis/p1/5544753-perfil-icone-design-gratis-vetor.jpg";
  const nomeUsuario = "João Silva";
  const emailUsuario = "joao.silva@email.com";

  const handleNovaReclamacao = () => {
    navigate("/nova-reclamacao");
  };

  return (
    <div className="usuario-container">
      <aside className="perfil-coluna">
        <div className="perfil-bola">
          <img src={imagemPerfil} alt="Perfil" />
        </div>
        <div className="perfil-info">
          <h2>{nomeUsuario}</h2>
          <p>{emailUsuario}</p>
        </div>
        <button className="reclamar-btn" onClick={handleNovaReclamacao}>
          Reclamar !!!
        </button>
        <button className="sair-btn" onClick={() => navigate("/")}>
          Sair
        </button>
      </aside>

      <main className="reclamacoes-coluna">
        {[...Array(10)].map((_, i) => (
          <div key={i} className="cartao-reclamacao">
            <div className="conteudo-reclamacao">
              <div>
                <h3>Reclamação {i + 1}</h3>
                <h3>Data {i + 1}</h3>
                <p>Descrição da reclamação {i + 1}</p>
              </div>
              <div className="acoes-reclamacao">
                <span title="Editar">✏️</span>
                <span title="Excluir">❌</span>
              </div>
            </div>
          </div>
        ))}
      </main>
    </div>
  );
};

export default Usuario;

// import React from "react";
// import "./Usuario.css";

// const Usuario: React.FC = () => {
// //   const imagemPerfil = "https://cdn-icons-png.flaticon.com/512/3736/3736502.png";
//   const imagemPerfil = "https://static.vecteezy.com/ti/vetor-gratis/p1/5544753-perfil-icone-design-gratis-vetor.jpg";
//   const nomeUsuario = "João Silva";
//   const emailUsuario = "joao.silva@email.com";

//   return (
//     <div className="usuario-container">
//       <aside className="perfil-coluna">
//         <div className="perfil-bola">
//           <img src={imagemPerfil} alt="Perfil" />
//         </div>
//         <div className="perfil-info">
//           <h2>{nomeUsuario}</h2>
//           <p>{emailUsuario}</p>
//         </div>
//       </aside>

//       <main className="reclamacoes-coluna">
//         {[...Array(20)].map((_, i) => (
//           <div key={i} className="cartao-reclamacao">
//             <h3>Reclamação {i + 1}</h3>
//             <h3>Data {i + 1}</h3>
//             <p>Descrição da reclamação {i + 1}</p>
//           </div>
//         ))}
//       </main>
//     </div>
//   );
// };

// export default Usuario;




// import React from "react";
// import "./Usuario.css";

// type Reclamação = {
//   id: number;
//   titulo: string;
//   descricao: string;
// };

// const reclamacoesExemplo: Reclamação[] = [
//   { id: 1, titulo: "Reclamação 1", descricao: "Descrição da reclamação 1" },
//   { id: 2, titulo: "Reclamação 2", descricao: "Descrição da reclamação 2" },
//   { id: 3, titulo: "Reclamação 3", descricao: "Descrição da reclamação 3" },
//   { id: 3, titulo: "Reclamação 3", descricao: "Descrição da reclamação 3" },
//   { id: 3, titulo: "Reclamação 3", descricao: "Descrição da reclamação 3" },
//   { id: 3, titulo: "Reclamação 3", descricao: "Descrição da reclamação 3" },
//   { id: 3, titulo: "Reclamação 3", descricao: "Descrição da reclamação 3" },
//   { id: 3, titulo: "Reclamação 3", descricao: "Descrição da reclamação 3" },
//   { id: 3, titulo: "Reclamação 3", descricao: "Descrição da reclamação 3" },
//   { id: 3, titulo: "Reclamação 3", descricao: "Descrição da reclamação 3" },
//   { id: 3, titulo: "Reclamação 3", descricao: "Descrição da reclamação 3" },
//   { id: 3, titulo: "Reclamação 3", descricao: "Descrição da reclamação 3" },
//   { id: 3, titulo: "Reclamação 3", descricao: "Descrição da reclamação 3" },
//   { id: 3, titulo: "Reclamação 3", descricao: "Descrição da reclamação 3" },
//   { id: 3, titulo: "Reclamação 3", descricao: "Descrição da reclamação 3" },
//   // Adicione mais para testar o scroll
// ];

// const Usuario: React.FC = () => {
//   const imagemPerfil = "https://cdn-icons-png.flaticon.com/512/17/17004.png"; // Coloque a URL da imagem ou genérica

//   return (
//     <div className="usuario-container">
//       <div className="perfil-bola">
//         <img src={imagemPerfil} alt="Perfil" />
//       </div>
//       <div className="lista-reclamacoes">
//         {reclamacoesExemplo.map((rec) => (
//           <div key={rec.id} className="cartao-reclamacao">
//             <h3>{rec.titulo}</h3>
//             <p>{rec.descricao}</p>
//           </div>
//         ))}
//       </div>
//     </div>
//   );
// };

// export default Usuario;
