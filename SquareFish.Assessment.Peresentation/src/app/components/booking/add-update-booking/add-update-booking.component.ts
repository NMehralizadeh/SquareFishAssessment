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

  booking: Booking;

  ngOnInit(): void {
    // this.loginService.login('admin', 'admin').subscribe((r) => {
    // environment.token = r['token'];
    debugger;
    const { id } = this.route.snapshot.params;
    if (id === undefined || id == -1) {
      this.booking = new Booking();
      this.booking.id = id;
    }
    this.getBooking(id);
    // });
  }
  getBooking(bookingId: number) {
    if (bookingId === undefined || bookingId == -1) return;
    this.bookingServie.getBookingDetailById(bookingId).subscribe((result) => {
      this.booking = result;
    });
  }

  update(bookingId: number) {
    if (bookingId === undefined || bookingId == -1) {
      this.bookingServie.createBooking(this.booking).subscribe();
    } else {
      this.bookingServie.updateBooking(bookingId, this.booking).subscribe();
    }
  }
}
