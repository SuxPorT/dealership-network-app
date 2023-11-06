import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Phone } from '../models/phone.model';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class PhoneService extends BaseService<Phone> {

  protected override endpoint: string = "Phones";

  constructor(protected override http: HttpClient) {
    super(http);
  }

}
