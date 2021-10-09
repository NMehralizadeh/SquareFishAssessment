import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Booking } from '../viewModels/Booking';
@Injectable({
  providedIn: 'root',
})
export class BookingService {
  constructor(private http: HttpClient) {}

  bookingControllerUrl: string = `${environment.baseUrl}`;
  getBookingList(pageNo?: number): Observable<Booking[]> {
    debugger;
    const headers = new HttpHeaders({
      Authorization: `Bearer ${environment.token}`,
    });
    return this.http.get<Booking[]>(
      `${this.bookingControllerUrl}api/Booking/?PageNo=${pageNo}`,
      {
        headers: headers,
      }
    );
  }

  getBookingDetailById(bookingId: number): Observable<Booking> {
    const headers = new HttpHeaders({
      Authorization: `Bearer ${environment.token}`,
    });
    return this.http.get<Booking>(
      `${this.bookingControllerUrl}api/Booking/${bookingId}`,
      {
        headers: headers,
      }
    );
  }

  createBooking(booking: Booking): Observable<number> {
    const headers = new HttpHeaders({
      Authorization: `Bearer ${environment.token}`,
    });
    return this.http.post<number>(`${this.bookingControllerUrl}api/Booking/`, {
      booking,
      headers: headers,
    });
  }

  updateBooking(bookingId: number, booking: Booking): Observable<number> {
    const headers = new HttpHeaders({
      Authorization: `Bearer ${environment.token}`,
    });
    return this.http.put<number>(
      `${this.bookingControllerUrl}api/Booking/${bookingId}`,
      {
        booking,
        headers: headers,
      }
    );
  }

  deleteBookingById(bookingId: number): Observable<number> {
    const headers = new HttpHeaders({
      Authorization: `Bearer ${environment.token}`,
    });
    return this.http.delete<number>(
      `${this.bookingControllerUrl}api/Booking/${bookingId}`,
      {
        headers: headers,
      }
    );
  }
}
