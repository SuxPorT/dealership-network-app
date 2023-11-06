import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Owner } from '../models/owner.model';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class OwnerService extends BaseService<Owner> {

  protected override endpoint: string = "Owners";

  constructor(protected override http: HttpClient) {
    super(http);
  }

}
