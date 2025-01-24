// import { Module } from '@nestjs/common';
// import { AppController } from './app.controller';
// import { AppService } from './app.service';
// import { NovomoduloModule } from './novomodulo/novomodulo.module';
// import { MySQLService } from './infraestrutura/mysql.service'; // é so um serviço, nao tem modulo na pasta, entao, deve ser inserido em "PROVIDERS"

// @Module({
//   imports: [NovomoduloModule],
//   controllers: [AppController],
//   providers: [AppService, MySQLService],
// })
// export class AppModule {}


import { Module } from '@nestjs/common';
import { AppController } from './app.controller';
import { AppService } from './app.service';
import { NovomoduloModule } from './novomodulo/novomodulo.module';
import { MySQLModule } from './infraestrutura/mysql.module';

@Module({
  imports: [NovomoduloModule, MySQLModule],  // agora que tudo foi condensado em um modulo, importamos or aqui
  controllers: [AppController],
  providers: [AppService],
})
export class AppModule {}
