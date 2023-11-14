import { BaseModel } from "./base-model.model";

export interface Owner extends BaseModel {
  cpfCnpj: string;
  hiringType: string;
  name: string;
  email: string;
  birthDate: Date;
  city: string;
  uf: string;
  cep: string;
}
