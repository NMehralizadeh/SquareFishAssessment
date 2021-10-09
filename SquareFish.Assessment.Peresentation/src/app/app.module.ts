import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavbarComponent } from './navbar/navbar.component';
import { AppRoutingModule } from './app-routing.module';
import { LoginService } from './services/login.service';
import { environment } from 'src/environments/environment';
import { ListBookingComponent } from './components/booking/list-booking/list-booking.component';
import { AddUpdateBookingComponent } from './components/booking/add-update-booking/add-update-booking.component';
import { ViewBookingComponent } from './components/booking/view-booking/view-booking.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    ListBookingComponent,
    AddUpdateBookingComponent,
    ViewBookingComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
  ],
  providers: [LoginService],
  bootstrap: [AppComponent],
})
export class AppModule {
  constructor(private loginService: LoginService) {
    this.setToken();
  }

  setToken() {
    this.loginService
      .login('admin', 'admin')
      .subscribe((r) => (environment.token = r['token']));
  }
}
