import { Body, Controller, Get, HttpCode, Post } from '@nestjs/common';
import { NovomoduloService } from './novomodulo.service';
import { CreateObjetoDto } from './dtos/criar-objetos.dto';

@Controller('novomodulo')
export class NovomoduloController {
    constructor(private readonly novomoduloService: NovomoduloService) {}

    @Get()
    novaMensagem() {
        return this.novomoduloService.novaMensagem();
    }
    
    @Post()
    @HttpCode(202) // serve so para alterar o codigo da respsota. Antes o do post era 201
    criarObjeto(@Body() createObjetoDto: CreateObjetoDto) {
        return this.novomoduloService.criarObjeto(createObjetoDto);
    }
    
}
