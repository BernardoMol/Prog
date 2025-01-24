import { Injectable, OnModuleDestroy } from '@nestjs/common';
import * as sql from 'mssql';

@Injectable()
export class MySQLService implements OnModuleDestroy {
  private pool: sql.ConnectionPool;

  // Método para criar a conexão
  async connect() {
    if (!this.pool) {
      try {
        // Conexão com o banco de dados 'BancoLocal'
        this.pool = await sql.connect({
          server: 'DESKTOP-DV5DOKH\\SQLEXPRESS',           // Nome ou IP do servidor
          database: 'BancoLocal',        // Nome do banco de dados ajustado para 'BancoLocal'
          driver: "msnodesqlv8",
          user: "sa",
          password: '1234',
          port: 1433,
          options: {
            trustedConnection: true
          }   
        });
        console.log('Conectado ao SQL Server com autenticação SQL');
      } catch (error) {
        console.error('Erro ao conectar ao SQL Server:', error);
        throw new Error('Falha na conexão com o banco de dados');
      }
    }
  }

  // Método para verificar se a conexão está ativa
  isConnected(): boolean {
    return !!this.pool;
  }

  // Método para executar uma consulta na tabela 'ObjetosEmSQL'
  async query(sqlQuery: string, params?: any[]) {
    if (!this.pool) {
      throw new Error('Conexão com o banco de dados não está ativa');
    }
    const request = this.pool.request();  // Prepara a requisição
    if (params) {
      params.forEach((param, index) => {
        request.input(`param${index}`, param);  // Insere parâmetros na consulta
      });
    }
    const result = await request.query(sqlQuery);  // Executa a consulta SQL
    return result.recordset;  // Retorna os resultados da consulta
  }

  // Método para fechar a conexão
  async onModuleDestroy() {
    if (this.pool) {
      await this.pool.close();  // Fecha a conexão com o banco
      console.log('Conexão com o SQL Server fechada');
    }
  }
}
