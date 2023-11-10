import { BaseModel } from "./base-model.model";

export interface Vehicle extends BaseModel {
  chassisNumber: string;
  model: string;
  year: number;
  color: string;
  price: number;
  mileage: number;
  systemVersion: string;
  ownerCpfCnpj: string;
}
