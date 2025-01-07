import { Component, Output, EventEmitter } from '@angular/core';


@Component({
  selector: 'app-change-number',
  templateUrl: './change-number.component.html',
  styleUrls: ['./change-number.component.css']
})
export class ChangeNumberComponent {
  @Output() eventoChangeNumber: EventEmitter<any> = new EventEmitter()
  mudarNumero(): void {
    console.log("Mudou o numero")
    this.eventoChangeNumber.emit()
  }
}
