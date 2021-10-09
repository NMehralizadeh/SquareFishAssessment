import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddUpdateBookingComponent } from './add-update-booking.component';

describe('AddUpdateBookingComponent', () => {
  let component: AddUpdateBookingComponent;
  let fixture: ComponentFixture<AddUpdateBookingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddUpdateBookingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddUpdateBookingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
