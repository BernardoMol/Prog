import { Component, OnInit } from '@angular/core';
import { Moment } from 'src/app/interface-moment';
import { MomentService } from 'src/app/services/moment.service';


@Component({
  selector: 'app-newmoment',
  templateUrl: './newmoment.component.html',
  styleUrls: ['./newmoment.component.css']
})
export class NewmomentComponent implements OnInit {
  btnText = 'Compartilhar'
  constructor(private momentService: MomentService) { }

  ngOnInit(): void {

  }

  async createHandler(moment: Moment) {
    
    // TRANSFORMANDO EM FORM DATA AO INVÉS DE JSON
    const formData = new FormData()
    
    formData.append("title", moment.title)
    formData.append("description", moment.description)
    if(moment.image){
      formData.append("image", moment.image)
    }

    await this.momentService.createMoment(formData).subscribe();

  }

}
