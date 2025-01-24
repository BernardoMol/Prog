import { Controller, Get } from '@nestjs/common';
import { MySQLService } from './mysql.service';

@Controller('rotamysql')
export class MySQLController {
  constructor(private readonly mysqlService: MySQLService) {}

  @Get('exemplo')
  async testConnection() {
    try {
      // Verifica se já existe uma conexão aberta, se não, cria uma nova
      if (!this.mysqlService.isConnected()) {
        await this.mysqlService.connect();
      }
      
      // Realiza a consulta na tabela ObjetosEmSQL
      const result = await this.mysqlService.query('SELECT * FROM ObjetosEmSQL');
      
      // Retorna os resultados da consulta
      return result;
    } catch (error) {
      // Tratar erro de conexão ou consulta
      throw new Error(`Erro ao conectar ou consultar o banco de dados: ${error.message}`);
    }
  }
}
