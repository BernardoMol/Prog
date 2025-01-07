import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-conditional-render',
  templateUrl: './conditional-render.component.html',
  styleUrls: ['./conditional-render.component.css'],
})
export class ConditionalRenderComponent {
  canShow: boolean = false;
  canShow2: boolean = true;
  userName = "Ml"
}
