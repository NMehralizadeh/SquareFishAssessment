import { Component, OnInit } from '@angular/core';
import { BookingService } from 'src/app/services/booking.service';
import { LoginService } from 'src/app/services/login.service';
import { environment } from 'src/environments/environment';
import { Booking } from './../../../viewModels/Booking';

@Component({
  selector: 'app-list-booking',
  templateUrl: './list-booking.component.html',
  styleUrls: ['./list-booking.component.css'],
})
export class ListBookingComponent implements OnInit {
  constructor(
    private bookingServie: BookingService,
    private loginService: LoginService
  ) {}

  ngOnInit(): void {
    // this.loginService.login('admin', 'admin').subscribe((r) => {
    // environment.token = r['token'];
    this.getBookings();
    // });
  }
  bookings: Booking[];
  getBookings() {
    this.bookingServie.getBookingList(1).subscribe((result) => {
      this.bookings = result;
    });
  }

  delete(bookingId : number) {
    this.bookingServie.deleteBookingById(bookingId).subscribe();
  }
}
