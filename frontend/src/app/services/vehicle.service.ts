import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Vehicle } from '../models/vehicle.model';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class VehicleService extends BaseService<Vehicle> {

  protected override endpoint: string = "Vehicles";

  constructor(protected override http: HttpClient) {
    super(http);
  }

}
