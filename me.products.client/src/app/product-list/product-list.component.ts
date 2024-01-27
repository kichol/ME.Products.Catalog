import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Product } from 'src/interfaces/product';
import { CatalogService } from '../catalog.service';
import { Router } from '@angular/router';
import { Observable, tap } from 'rxjs';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent {

  products: Product[];
  products$: Observable<Product[]>;
  constructor(private router: Router,
    private catalogService: CatalogService) {
    this.catalogService.productsChanged.subscribe(result => this.products = result);
    
    this.products$ = this.catalogService.pagesOutput;
    this.products$.subscribe(products => {
        this.products = products;
        console.log(products);
    });
   
    this.catalogService.getPage(1);  


  }

  ngOnInit() {
    // this.products$ = this.catalogService.getProducts();
    // this.products$.subscribe(
    //   {
    //     next: response => {
    //       this.products = response;
    //     },
    //     error: error => { console.log('There was and error loading products! ', error) },

    //   });
  }

  editClicked(index: number) {
    const product = this.products[index];
    const id = product.productId;
    this.router.navigateByUrl('/edit/' + id);
  }

  deleteClicked(event: any) {
    const productId = this.products[event].productId;
    console.log(productId);
    this.catalogService.deleteProduct(productId)
      .subscribe(
        {
          next: response => {
           // this.catalogService.getProducts().subscribe();
           this.catalogService.getPage(1);
          },
          error: error => { console.log('There was and error loading product! ', error) },

        });
  }

}




