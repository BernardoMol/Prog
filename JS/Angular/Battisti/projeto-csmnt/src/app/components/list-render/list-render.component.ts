import { Component } from '@angular/core';
import { Animal } from 'src/app/InterfaceAnimal';
import { ListService } from 'src/app/services/list.service';
@Component({
  selector: 'app-list-render',
  templateUrl: './list-render.component.html',
  styleUrls: ['./list-render.component.css']
})
export class ListRenderComponent {

  // animals: Animal[] = [
  //   {name:"Manu", type: "dog", age: 5},
  //   {name:"Izac", type: "cat", age: 2},
  //   {name:"Julie", type: "dog",  age: 6},
  //   {name:"Herman", type: "Stone?",  age: 7},
  // ];

  animals: Animal[] = []

  animal: Animal = {
    id: 80,
    name:"Herman",
    type: "Stone?",
    age: 7,  
  };

  animalAge = ''
  selectedAnimal: Animal | null = null // o "ou" dos caras tem um pau a menos KKKKKKKKKKKK!!!!!!!!!!

  constructor(private listService: ListService){
    this.getAnimals()
  }

  showAge(animal: Animal): void {
    this.selectedAnimal = animal    
  }
  removeAnimal(animal: Animal){
    console.log('Removendo animal')
    //if (this.selectedAnimal){
      // this.animals = this.listService.remove(this.animals, animal) // funciona mas n precisa passar o objeto todo
    //}

    this.animals = this.animals.filter((a) => animal.name !== a.name) // aqui estamos excluindo no Front End
    this.listService.remove(animal.id).subscribe() // Aqui estamos excluindo no banco de dados (Back End) que no nosso caso é o arquivo "bd.json"

  }
  getAnimals(): void {
    // this.animals = this.listService.getAll() // esta aqui nao pode porque estamos usando "OBSERVE", entao tem que usar "subscribe"
    this.listService.getAll().subscribe((animalsRetornadosDaRequisicao) => this.animals = animalsRetornadosDaRequisicao)
  }
}
