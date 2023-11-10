import { BaseModel } from "./base-model.model";

export interface Sale extends BaseModel {
  price: number;
  vehicleChassisNumber: string;
  sellerId: number;
}
