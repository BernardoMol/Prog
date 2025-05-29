import React from 'react'
import './Cartao.css'
interface Props {
  fotoDoUsuario: string;
  nomeDoUsuario: string;
  comentario: string;
  dataComentario: string;
} // a interface checa os dados e o spelling, como esta a escrita

const Cartao = ( { fotoDoUsuario, nomeDoUsuario, dataComentario, comentario}  : Props) => {
  
  const exibir = (e: React.ChangeEvent<HTMLTextAreaElement>) => {
    console.log(e.target.value);
    // console.log(e);
  }
  
  return (
    <div className='Card'>
      <h4> 
        <img
          src="https://www.portosrs.com.br/site/public/uploads/site/noticias/1892/1892_1.jpg"
          alt="Foto do Usuário"
        />
        <span className="nomeUsuario">{nomeDoUsuario}</span>
        <span className="dataComentario">{dataComentario}</span>
      </h4>
      <textarea
        className="inputComentario"
        onChange={ (e) => exibir(e) }
        defaultValue='Escreva seu comentário'
      ></textarea>
      {/* <h3> 
        <span className="caixaComentario">{comentario}</span>    
      </h3>
      <input onChange={ (e) => exibir(e) }></input> */}
    </div>
  );
}

export default Cartao