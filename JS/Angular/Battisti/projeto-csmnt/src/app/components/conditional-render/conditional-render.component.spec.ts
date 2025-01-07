import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConditionalRenderComponent } from './conditional-render.component';

describe('ConditionalRenderComponent', () => {
  let component: ConditionalRenderComponent;
  let fixture: ComponentFixture<ConditionalRenderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ConditionalRenderComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ConditionalRenderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
