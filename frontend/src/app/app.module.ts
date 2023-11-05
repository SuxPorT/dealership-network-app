import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AngularMaterialModule } from './modules/angular-material/angular-material.module';
import { HeaderComponent } from './components/static/header/header.component';
import { FooterComponent } from './components/static/footer/footer.component';
import { BodyComponent } from './components/static/body/body.component';
import { LeftMenuComponent } from './components/static/left-menu/left-menu.component';
import { HomeComponent } from './components/views/home/home.component';
import { AccessoryComponent } from './components/views/accessory/accessory.component';
import { PhoneComponent } from './components/views/phone/phone.component';
import { OwnerComponent } from './components/views/owner/owner.component';
import { SaleComponent } from './components/views/sale/sale.component';
import { SellerComponent } from './components/views/seller/seller.component';
import { VehicleComponent } from './components/views/vehicle/vehicle.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    BodyComponent,
    LeftMenuComponent,
    HomeComponent,
    AccessoryComponent,
    PhoneComponent,
    OwnerComponent,
    SaleComponent,
    SellerComponent,
    VehicleComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    AngularMaterialModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
