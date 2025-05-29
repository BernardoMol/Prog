import React from 'react'
import Cartao from '../Cartoes/Cartao'
import { Reclamacao } from '../../TiposDeDados';

// type Props = {}
// const ListaCartoes = (props: Props) => {

// 1. Defina as props que o componente ListaCartoes vai receber
type ListaCartoesProps = {
  reclamacoes: Reclamacao[]; // Ele vai receber um array de Reclamacao
}

const ListaCartoes = ({ reclamacoes }: ListaCartoesProps) => {
  return (
    <div>
      {reclamacoes.length === 0 ? ( <p>Nenhuma reclamação para exibir.</p> ) 
      :
      ( reclamacoes.map((reclamacao) => (
        <Cartao 
          key={reclamacao.id} // Use o ID da reclamação como key
          fotoDoUsuario="foto-padrao.png" // Você pode precisar adicionar uma lógica para fotos de usuário
          nomeDoUsuario="Anônimo" // Adapte isso se sua reclamação tiver nome de usuário
          // Converta a data se a reclamação tiver uma data (ex: new Date().toLocaleDateString())
          dataComentario="Data da Reclamação" 
          comentario={reclamacao.conteudo} 
        />
        ))
      )}
        {/* <Cartao fotoDoUsuario="foto1" nomeDoUsuario="usuario1" dataComentario="29/12/2025" comentario="1 Comentario bem bobo" />
        <Cartao fotoDoUsuario="foto2" nomeDoUsuario="usuario2" dataComentario="30/12/2025" comentario="2 Comentario bem bobo" />
        <Cartao fotoDoUsuario="foto3" nomeDoUsuario="usuario3" dataComentario="31/12/2025" comentario="3 Comentario bem bobo" /> */}
    </div>
  
  )
}

export default ListaCartoes