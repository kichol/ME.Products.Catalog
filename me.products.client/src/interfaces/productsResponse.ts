import { Product } from "./product";

export interface ProductsResponse {
    totalCount: number;
    products: Product[];
  }