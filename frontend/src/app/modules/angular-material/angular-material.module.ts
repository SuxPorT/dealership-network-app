import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatSidenavModule } from '@angular/material/sidenav';

const materialModules = [
  MatButtonModule,
  MatIconModule,
  MatToolbarModule,
  MatSidenavModule
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    materialModules
  ],
  exports: [
    materialModules
  ]
})
export class AngularMaterialModule { }
