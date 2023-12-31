import { DEFAULT_CURRENCY_CODE, LOCALE_ID, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import ptBr from '@angular/common/locales/pt';

import { AppRoutingModule } from './app-routing.module';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
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
import { EditDialogComponent } from './components/shared/edit-dialog/edit-dialog.component';
import { DeleteDialogComponent } from './components/shared/delete-dialog/delete-dialog.component';
import { SnackbarInterceptor } from './interceptor/snackbar.interceptor';
import { DEFAULT_TIMEOUT, SpinnerInterceptor } from './interceptor/spinner.interceptor';
import { MAT_DATE_LOCALE } from '@angular/material/core';
import { registerLocaleData } from '@angular/common';

registerLocaleData(ptBr);

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
    VehicleComponent,
    EditDialogComponent,
    DeleteDialogComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    AngularMaterialModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: SnackbarInterceptor,
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: SpinnerInterceptor,
      multi: true
    }, {
      provide: DEFAULT_TIMEOUT,
      useValue: 30000
    },
    {
      provide: MAT_DATE_LOCALE,
      useValue: 'en-GB'
    },
    {
      provide: LOCALE_ID,
      useValue: 'pt-BR',
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
