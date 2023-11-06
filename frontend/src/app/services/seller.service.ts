import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Seller } from '../models/seller.model';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class SellerService extends BaseService<Seller> {

  protected override endpoint: string = "Sellers";

  constructor(protected override http: HttpClient) {
    super(http);
  }

}
