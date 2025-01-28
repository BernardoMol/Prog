import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';
import { environment } from './environments/environment';

if (environment.production) {
  enableProdMode();
}

platformBrowserDynamic().bootstrapModule(AppModule)
  .catch(err => console.error(err));


  // versão do angular utilizada:
  // consultar versão do angular: ng version
  // Startando a aplicação: ng serve
  // geralmente ele usa a porta 4200 --> http://localhost:4200/
  // Criando componente: ng generate component nomedapasta/nopedocomponenete (o mesmo se aplica para services, controllers, etc)
  // Para iniciar a API, em paralelo, entre na pasta onde esta o projeto da api, clique com o botao direito, abra no bash e digite "node ace serve"
  // ng add @fortawesome/angular-fontawesome --> biblioteca de icones instalada diretamente no angular, ja tem integração imediata com angular