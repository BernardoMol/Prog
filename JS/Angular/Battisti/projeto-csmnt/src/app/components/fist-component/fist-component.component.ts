import { Component } from '@angular/core';

@Component({
  selector: 'app-fist-component',
  templateUrl: './fist-component.component.html',
  styleUrls: ['./fist-component.component.css'],
})
export class FistComponentComponent {
  name = 'Mol';
  hobbies =  ['Jogar', 'Nadar', 'Cozinhar'];
  car = {
    modelo: 'Punto',
    ano: 2008,  
  }
  constructor(){}

  ngOnInit(): void {

  }

}

