import { Component, OnInit } from '@angular/core';
import { Animal } from 'src/app/InterfaceAnimal';

import { ListService } from 'src/app/services/list.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-item-detail',
  templateUrl: './item-detail.component.html',
  styleUrls: ['./item-detail.component.css']
})
export class ItemDetailComponent implements OnInit {
  animalBuscado?: Animal;

  constructor(private listService: ListService, private route: ActivatedRoute) { 
    this.getAnimal()    
  }


  ngOnInit(): void {
  }
  getAnimal(){
    const idDoAnimal = Number(this.route.snapshot.paramMap.get("id"))
    this.listService.getItem(idDoAnimal).subscribe((animalRetornadoPeloId) => this.animalBuscado = animalRetornadoPeloId)
  }

}
