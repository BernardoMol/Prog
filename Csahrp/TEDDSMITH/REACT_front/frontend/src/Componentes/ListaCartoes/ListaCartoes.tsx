import React from 'react'
import Cartao from '../Cartoes/Cartao'

type Props = {}

const ListaCartoes = (props: Props) => {
  return (
    <div>
        <Cartao fotoDoUsuario="foto1" nomeDoUsuario="usuario1" dataComentario="29/12/2025" comentario="1 Comentario bem bobo" />
        <Cartao fotoDoUsuario="foto2" nomeDoUsuario="usuario2" dataComentario="30/12/2025" comentario="2 Comentario bem bobo" />
        <Cartao fotoDoUsuario="foto3" nomeDoUsuario="usuario3" dataComentario="31/12/2025" comentario="3 Comentario bem bobo" />
    </div>
  )
}

export default ListaCartoes