import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DailyWordComponent } from './daily-word.component';

describe('DailyWordComponent', () => {
  let component: DailyWordComponent;
  let fixture: ComponentFixture<DailyWordComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DailyWordComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DailyWordComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
