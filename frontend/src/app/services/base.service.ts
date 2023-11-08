import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BaseService<TModel> {

  protected endpoint: string;

  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*',
      timeout: `${90000}`
    })
  };

  constructor(protected http: HttpClient) { }

  getAll(): Observable<TModel[]> {
    return this.http.get<TModel[]>(
      `${environment.apiUri}/${this.endpoint}`, this.httpOptions
    );
  }

  create(model: TModel): Observable<TModel> {
    return this.http.post<TModel>(
      `${environment.apiUri}/${this.endpoint}`, model, this.httpOptions
    );
  }

  update(model: TModel, id: number): Observable<TModel> {
    return this.http.put<TModel>(
      `${environment.apiUri}/${this.endpoint}/${id}`, model, this.httpOptions
    );
  }

  delete(id: number): Observable<any> {
    return this.http.delete(
      `${environment.apiUri}/${this.endpoint}/${id}`, this.httpOptions
    );
  }

}
