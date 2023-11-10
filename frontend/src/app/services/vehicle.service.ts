import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Vehicle } from '../models/vehicle.model';

@Injectable({
  providedIn: 'root'
})
export class VehicleService {

  protected endpoint = "Vehicles";

  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*',
      timeout: `${90000}`
    })
  };

  constructor(protected http: HttpClient) { }

  getAll(): Observable<Vehicle[]> {
    return this.http.get<Vehicle[]>(
      `${environment.apiUri}/${this.endpoint}`, this.httpOptions
    );
  }

  create(model: Vehicle): Observable<Vehicle> {
    return this.http.post<Vehicle>(
      `${environment.apiUri}/${this.endpoint}`, model, this.httpOptions
    );
  }

  update(model: Vehicle, chassisNumber: string): Observable<Vehicle> {
    return this.http.put<Vehicle>(
      `${environment.apiUri}/${this.endpoint}/UpdateByChassis/${chassisNumber}`,
      model, this.httpOptions
    );
  }

  delete(chassisNumber: string): Observable<Vehicle> {
    return this.http.delete<Vehicle>(
      `${environment.apiUri}/${this.endpoint}/DeleteByChassis/${chassisNumber}`,
      this.httpOptions
    );
  }

}
