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
          id={reclamacao.id.toString()}
          fotoDoUsuario={reclamacao.imagem} // Você pode precisar adicionar uma lógica para fotos de usuário
          nomeDoUsuario={"FIXO"} // Adapte isso se sua reclamação tiver nome de usuário
          // Converta a data se a reclamação tiver uma data (ex: new Date().toLocaleDateString())
          dataComentario={"FIXO"}
          comentario={reclamacao.conteudo} 
        />
        ))
      )}
    </div>
  
  )
}

export default ListaCartoes