import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Product } from '../interfaces/product';
import { ProductResponse } from '../interfaces/productResponse';
import { BehaviorSubject, Observable, Subject, map, pluck, switchMap, tap } from 'rxjs';
import { ProductsResponse } from 'src/interfaces/productsResponse';

  


 @Injectable({
  providedIn: 'root'
})
 export class CatalogService {
   
   rootDirectory = 'https://localhost:7088/api';
   products: Product[];
   productsChanged = new Subject<Product[]>();
   
   private pageSize = 3;
   private sortBy = 'Code';
   private sortAsc = true;

   private pagesInput: Subject<number>;
   pagesOutput: Observable<Product[]>;
   numberOfPages: Subject<number>;
  
  constructor(private http : HttpClient) {
      this.productsChanged.subscribe(result=> this.products = result);
      
      this.numberOfPages = new Subject();
      this.pagesInput = new Subject();
      this.pagesOutput = this.pagesInput.pipe(
        map(page => {
          return new HttpParams()
          .set('pageSize',String(this.pageSize))
          .set('page', String(page))
          .set('sortBy', this.sortBy);
        }),
      switchMap(params => {
        return this.http.get<ProductsResponse>(`${this.rootDirectory}/products/GetPagedProducts`, {params})
      }),
      tap(response => {
        const totalPages = Math.ceil(response.totalCount / this.pageSize);
        this.numberOfPages.next(totalPages);
      }),
      pluck('products'),
      tap(result => this.productsChanged.next(result))
    );
  }

  getPage(page: number){
    this.pagesInput.next(page);
  }

 getProducts()  {
   return this.http.get<Product[]>(`${this.rootDirectory}/products`).pipe(
    tap(result => {
      this.productsChanged.next(result);}
    ));
   }
   
   
createProduct(product: Product) {
  return this.http.post<ProductResponse>(`${this.rootDirectory}/products`, product);
    
}

editProduct(product: Product) {
  return this.http.put(`${this.rootDirectory}/products`, product);

}

deleteProduct(productId: string){
  return this.http.delete(`${this.rootDirectory}/products/${productId}`);
}




}
