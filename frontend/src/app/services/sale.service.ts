import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Sale } from '../models/sale.model';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class SaleService extends BaseService<Sale> {

  protected override endpoint: string = "Sales";

  constructor(protected override http: HttpClient) {
    super(http);
  }

}
