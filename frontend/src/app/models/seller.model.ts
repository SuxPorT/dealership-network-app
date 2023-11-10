import { BaseModel } from "./base-model.model";

export interface Seller extends BaseModel {
  name: string;
  baseSalary: number;
}
