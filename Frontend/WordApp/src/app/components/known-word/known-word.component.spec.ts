import { ComponentFixture, TestBed } from '@angular/core/testing';

import { KnownWordComponent } from './known-word.component';

describe('KnownWordComponent', () => {
  let component: KnownWordComponent;
  let fixture: ComponentFixture<KnownWordComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [KnownWordComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(KnownWordComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
