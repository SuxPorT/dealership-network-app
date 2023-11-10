import { BaseModel } from "./base-model.model";

export interface Phone extends BaseModel {
  number: string;
  ownerCpfCnpj: string;
}
