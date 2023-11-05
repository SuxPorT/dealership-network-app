import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Accessory } from '../models/accessory.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AccessoryService {

  private endpoint: string = "Accessories";

  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*',
      timeout: `${90000}`
    })
  };

  constructor(private http: HttpClient) { }

  getAll(): Observable<Accessory[]> {
    return this.http.get<Accessory[]>(
      `${environment.apiUri}/${this.endpoint}`, this.httpOptions
    );
  }

}
