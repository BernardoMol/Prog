import { Module } from '@nestjs/common';
import { NovomoduloController } from './novomodulo.controller';
import { NovomoduloService } from './novomodulo.service';

@Module({
  controllers: [NovomoduloController],
  providers: [NovomoduloService]
})
export class NovomoduloModule {}
