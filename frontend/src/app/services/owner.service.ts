import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Owner } from '../models/owner.model';

@Injectable({
  providedIn: 'root'
})
export class OwnerService {

  protected endpoint = "Owners";

  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*',
      timeout: `${90000}`
    })
  };

  constructor(protected http: HttpClient) { }

  getAll(): Observable<Owner[]> {
    return this.http.get<Owner[]>(
      `${environment.apiUri}/${this.endpoint}`, this.httpOptions
    );
  }

  create(model: Owner): Observable<Owner> {
    return this.http.post<Owner>(
      `${environment.apiUri}/${this.endpoint}`, model, this.httpOptions
    );
  }

  update(model: Owner, cpfCnpj: string): Observable<Owner> {
    return this.http.put<Owner>(
      `${environment.apiUri}/${this.endpoint}/UpdateByCpfCnpj/${cpfCnpj}`, model, this.httpOptions
    );
  }

  delete(cpfCnpj: string): Observable<any> {
    return this.http.delete(
      `${environment.apiUri}/${this.endpoint}/DeleteByCpfCnpj/${cpfCnpj}`, this.httpOptions
    );
  }

}
