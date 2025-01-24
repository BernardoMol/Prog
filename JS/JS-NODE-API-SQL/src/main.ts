import { NestFactory } from '@nestjs/core';
import { AppModule } from './app.module';

async function bootstrap() {
  const app = await NestFactory.create(AppModule);
  await app.listen(process.env.PORT ?? 3000);
}
bootstrap();
// INICIAR APLICAÇÃO: npm run start:dev

// Criando um novo modulo/contolador/service : nest g (module ou contoller ou service) nomeDoNovoElemento

// Precisamos de um controler, que vai estabelecer as rotas, um service, que vai usar as rotas e um modulo, que vai agrupar tudo
// CONTROLADOR: Em uma API, o controlador é quem define as rotas e como elas devem ser processadas.
// SERVICE: Define as regras de negocios, entao ela usa o que esta definido no controller
// MODULO: Agrupa os services e controlers ->
// -> Exemplo: Se você estiver construindo um sistema de usuários, 
//    o módulo de usuários poderia conter todos os controladores e serviços relacionados a usuários.
//    (me lembrou dos boxes da sydle)