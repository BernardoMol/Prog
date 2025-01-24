import { Module } from '@nestjs/common';
import { MySQLService } from './mysql.service';
import  {MySQLController} from './mysql.controller';

@Module({
  imports: [],  // Caso precise importar outros módulos, adicione aqui
  controllers: [MySQLController],  // Adiciona o controlador no módulo
  providers: [MySQLService],  // Registra o serviço no módulo
  exports: [MySQLService],  // Exporta o serviço, caso precise utilizá-lo em outros módulos
})
export class MySQLModule {}