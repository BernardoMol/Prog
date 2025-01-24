import { HttpException, HttpStatus, Injectable } from '@nestjs/common';
import { Objeto } from './novainterface/interface';
import { CreateObjetoDto } from './dtos/criar-objetos.dto';

@Injectable()
export class NovomoduloService {
private objetos: Objeto[] = []

    // novaMensagem() {
    //     return {message: "Hello world"}
    // }
    novaMensagem() {
        return this.objetos
    }

    criarObjeto(createObjetoDto: CreateObjetoDto) {
        
        const acharObjeto = this.objetos.find((objeto) => objeto.name === createObjetoDto.name)
        if(acharObjeto){
            throw new HttpException('Objeto com esse nome ja existe', HttpStatus.BAD_REQUEST)
        }


        const objetoNovo: Objeto ={
            // Mesmo que o ID seja obrigatorio, ele nao é obrigatorio ao enviar a mensagen pelo postman
            // Se ele for criado por aqui e colocado no objeto, da certo
            // Entao o nome e outras propriaedades tambem nao precisam ser enviadas, mas, neste caso, precisam OBRIGATORIAMENTE ser criadas por aqu
            // O "problema" de gerar o ID por aqui é precisar garantir que os IDs nao sejam iguials
            // isso é implementado na regra de negocios (service)
            // mas para isso, é necessario colocar a propriedade "id" no dto....como nao querof azer isso, vou verificar/impedir os nomes de serem iguais
            id: (Math.random() * 1e18).toString(36),
            ...createObjetoDto,
        }
        this.objetos.push(objetoNovo);

        return objetoNovo;
    }

}

