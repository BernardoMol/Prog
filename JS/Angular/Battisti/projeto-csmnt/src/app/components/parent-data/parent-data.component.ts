import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-parent-data',
  templateUrl: './parent-data.component.html',
  styleUrls: ['./parent-data.component.css']
})
export class ParentDataComponent {
  @Input() name: string = '';
  @Input() dadosDeUsuario!: {email: string, formacao: string}; // a exclamação ao lado de "dadosDeUsuario" indica inicialização com dado vazio

}
