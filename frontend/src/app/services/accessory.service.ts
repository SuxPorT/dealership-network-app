import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Accessory } from '../models/accessory.model';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class AccessoryService extends BaseService<Accessory> {
  protected override endpoint: string = "Accessories";

  constructor(protected override http: HttpClient) {
    super(http);
  }

}
