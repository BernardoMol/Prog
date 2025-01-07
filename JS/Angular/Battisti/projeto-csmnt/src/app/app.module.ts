import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { AppComponent } from './app.component';
import { DirectivesComponent } from "./components/directives/directives.component";
import { EmiterComponent } from "./components/emiter/emiter.component";
import { FistComponentComponent } from './components/fist-component/fist-component.component';
import { ConditionalRenderComponent } from './components/conditional-render/conditional-render.component';
import { EventosComponent } from './components/eventos/eventos.component';
import { ListRenderComponent } from './components/list-render/list-render.component';
import { ParentDataComponent } from './components/parent-data/parent-data.component';
import { PipesComponent } from './components/pipes/pipes.component';
import { ChangeNumberComponent } from './components/change-number/change-number.component';
import { TwoWayBindingComponent } from './components/two-way-binding/two-way-binding.component';

import { AppRoutingModule } from './app-routing.module';

import {HttpClientModule} from '@angular/common/http';
import { ItemDetailComponent } from './components/item-detail/item-detail.component'

@NgModule({
  declarations: [
    AppComponent,
    FistComponentComponent,
    EmiterComponent,
    ConditionalRenderComponent,
    EventosComponent,
    ListRenderComponent,
    ParentDataComponent,
    PipesComponent,
    DirectivesComponent,
    ChangeNumberComponent,
    TwoWayBindingComponent,
    ItemDetailComponent
  ],
  imports: [
    BrowserModule,
    CommonModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule
],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
