import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FistComponentComponent } from './fist-component.component';

describe('FistComponentComponent', () => {
  let component: FistComponentComponent;
  let fixture: ComponentFixture<FistComponentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FistComponentComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FistComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
