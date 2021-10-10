import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListBookingComponent } from './components/booking/list-booking/list-booking.component';
import { AddUpdateBookingComponent } from './components/booking/add-update-booking/add-update-booking.component';
import { ViewBookingComponent } from './components/booking/view-booking/view-booking.component';

const routes: Routes = [
  { path: 'booking', component: ListBookingComponent },
  { path: 'booking/item/:id', component: AddUpdateBookingComponent },
  { path: 'booking/view/:id', component: ViewBookingComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
