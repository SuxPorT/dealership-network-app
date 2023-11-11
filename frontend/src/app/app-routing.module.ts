import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/views/home/home.component';
import { AccessoryComponent } from './components/views/accessory/accessory.component';
import { OwnerComponent } from './components/views/owner/owner.component';
import { PhoneComponent } from './components/views/phone/phone.component';
import { SaleComponent } from './components/views/sale/sale.component';
import { SellerComponent } from './components/views/seller/seller.component';
import { VehicleComponent } from './components/views/vehicle/vehicle.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', component: HomeComponent },
  { path: 'home', component: HomeComponent },
  { path: 'accessory', component: AccessoryComponent },
  { path: 'owner', component: OwnerComponent },
  { path: 'phone', component: PhoneComponent },
  { path: 'sale', component: SaleComponent },
  { path: 'seller', component: SellerComponent },
  { path: 'vehicle', component: VehicleComponent },
  { path: '**', redirectTo: '/home' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
