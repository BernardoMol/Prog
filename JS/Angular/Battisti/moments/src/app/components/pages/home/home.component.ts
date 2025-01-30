import { Component, OnInit } from '@angular/core';
import { MomentService } from 'src/app/services/moment.service';
import { Moment } from 'src/app/interface-moment';
import { environment } from 'src/environments/environment';
import { faSearch } from '@fortawesome/free-solid-svg-icons';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  allMoments: Moment[] = [];
  moments: Moment[] = [];
  baseApiUrl = environment.baseApiUrl;

  faSearch = faSearch;
  searchTerm: string = '';

  constructor(private momentService: MomentService) { }

  ngOnInit(): void {
    this.momentService.getMoments().subscribe((items) => {

      const data = items.data
      data.map((items) => {
        items.created_at = new Date(items.created_at!).toLocaleDateString('pt-BR') // facinho de formatar a data....
      });

      this.allMoments = data;
      this.moments = data;

    });    
  }
  
  searchMoment(e: Event): void{
    const target = e.target as HTMLInputElement;
    const value = target.value;

    this.moments = this.allMoments.filter( (moment) => {
      return moment.title?.toLocaleLowerCase().includes(value)
    });
  }
}
