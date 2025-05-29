import React from 'react'
import './Cartao.css'


// ISSO AQUI É NO FUTURO
// MEU BANCO AINDA NAO ESTA DESSA FORMA, ELE SO TEM ID, COMENTARIO E FOTO
// interface Props {
//   fotoDoUsuario: string;
//   nomeDoUsuario: string;
//   comentario: string;
//   dataComentario: string;
// } // a interface checa os dados e o spelling, como esta a escrita
// const Cartao = ( { fotoDoUsuario, nomeDoUsuario, dataComentario, comentario}  : Props) => {




// SE EU QUISESSE PASSAR COMO OBJETO, SERIA MAIS CHATO
// 1. Defina a interface (ou type) para o objeto que VAI CONTER as props do Cartao
// type PropriedadesDoCartaoObjeto = {
//   id: string; // Se você for usar o ID dentro do Cartao, pode incluí-lo aqui.
//   fotoDoUsuario: string | null;
//   nomeDoUsuario: string;
//   dataComentario: string;
//   comentario: string;
// }

// // 2. Defina a interface para as props do componente Cartao,
// // onde 'propriedadesCartao' é um objeto do tipo acima.
// type CartaoProps = {
//   propriedadesCartao: PropriedadesDoCartaoObjeto; // <-- Agora 'propriedadesCartao' é um objeto
// }
// const Cartao = ({ propriedadesCartao }: CartaoProps) => {


type CartaoProps = {
  id: string;
  fotoDoUsuario: string | null;
  comentario: string;
  // essas duas ainda vou dexar hard coded porque meu banco ainda esta diferente
  nomeDoUsuario: string;
  dataComentario: string;
}

const Cartao = ({ id, fotoDoUsuario, comentario, nomeDoUsuario, dataComentario}: CartaoProps) => {
  
  
  // VERIFICANDO NO CONSOLE
  console.log("Cartão ID:", id);
  console.log("Foto do Usuário:", fotoDoUsuario);
  console.log("Comentário:", comentario);
  console.log("Nome do Usuário:", nomeDoUsuario);
  console.log("Data do Comentário:", dataComentario);
  console.log("--- Fim das Props do Cartão ---");
  
  
  
  const exibir = (e: React.ChangeEvent<HTMLTextAreaElement>) => {
    console.log(e.target.value);
    // console.log(e);
  }
  
  return (
    <div className='Card'>
      <h4> 
        <img
          src={fotoDoUsuario || "https://www.portosrs.com.br/site/public/uploads/site/noticias/1892/1892_1.jpg"}
          alt="Foto do Usuário"
        />
        <span className="nomeUsuario">{nomeDoUsuario || "NOME fixo"}</span>
        <span className="dataComentario">{dataComentario || "DATA fixa"}</span>
      </h4>
      <textarea
        className="inputComentario"
        onChange={ (e) => exibir(e) }
        defaultValue={comentario}
      ></textarea>
      {/* <h3> 
        <span className="caixaComentario">{comentario}</span>    
      </h3>
      <input onChange={ (e) => exibir(e) }></input> */}
    </div>
  );
}

export default Cartao