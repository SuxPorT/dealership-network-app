import { BaseModel } from "./base-model.model";

export interface Owner extends BaseModel {
  cpfCnpj: string;
  hiringType: string;
  name: string;
  birthDate: Date;
  city: string;
  uf: string;
  cep: string;
}
