import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Product } from '../interfaces/product';
import { ProductResponse } from '../interfaces/productResponse';
import { BehaviorSubject, Subject } from 'rxjs';


 @Injectable({
  providedIn: 'root'
})
 export class CatalogService {
   
   rootDirectory = 'https://localhost:7088/api';
   products: Product[];
   productsChanged = new Subject<Product[]>();

  
  constructor(private http : HttpClient) { }


 getProducts()  {
   return this.http.get<Product[]>(`${this.rootDirectory}/products`)
     .subscribe(
       {
         next: response => {
           this.products = response;
           this.productsChanged.next(this.products);
         },
         error: error => { console.log('There was and error loading product! ', error) },

       });
}


createProduct(product: Product) {
  return this.http.post<ProductResponse>(`${this.rootDirectory}/products`, product)
    .subscribe(response => {
      if (response.product) {
        this.products = [...this.products, response.product];
        this.productsChanged.next(this.products);
      }
    });
}

editProduct(product: Product) {
  return this.http.put(`${this.rootDirectory}/products`, product)
    .subscribe(
      {
        next: response => {
          this.getProducts();
        },
        error: error => { console.log('There was and error loading product! ', error) },

      });
}

deleteProduct(productId: string){
  return this.http.delete(`${this.rootDirectory}/products/${productId}`)
    .subscribe(
      {
        next: response => {
          this.getProducts();
        },
        error: error => { console.log('There was and error loading product! ', error) },

      });
}


}
