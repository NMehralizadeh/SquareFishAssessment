import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BookingService } from 'src/app/services/booking.service';
import { LoginService } from 'src/app/services/login.service';
import { Booking } from 'src/app/viewModels/Booking';

@Component({
  selector: 'app-add-update-booking',
  templateUrl: './add-update-booking.component.html',
  styleUrls: ['./add-update-booking.component.css'],
})
export class AddUpdateBookingComponent implements OnInit {
  constructor(
    private bookingServie: BookingService,
    private loginService: LoginService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    // this.loginService.login('admin', 'admin').subscribe((r) => {
    // environment.token = r['token'];
    const { id } = this.route.snapshot.params;
    this.getBooking(id);
    // });
  }
  booking: Booking;
  getBooking(bookingId: number) {
    this.bookingServie.getBookingDetailById(bookingId).subscribe((result) => {
      this.booking = result;
    });
  }

  update(bookingId: number) {
    debugger;
    if (bookingId === undefined || bookingId === 0) {
      this.bookingServie.createBooking(this.booking);
    } else {
      this.bookingServie.updateBooking(bookingId, this.booking);
    }
  }
}
