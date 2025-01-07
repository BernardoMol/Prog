import { Component } from '@angular/core';
import { ChangeNumberComponent as ChangeNumberComponent } from "../change-number/change-number.component";

@Component({
  selector: 'app-emiter',
  templateUrl: './emiter.component.html',
  styleUrls: ['./emiter.component.css']
})
export class EmiterComponent {
  myNumber = 0;

  onEventoChangeNumber(){
    this.myNumber = Math.floor(Math.random()*10)
    // alert('Deu Certo')
  }


}
