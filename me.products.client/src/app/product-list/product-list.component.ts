import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Product, ProductListResponse } from 'src/interfaces/product';
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
  totalCount: number;
  numberOfPages: number;
  
  constructor(private router: Router,
    private catalogService: CatalogService) {

    this.catalogService.productsChanged.subscribe(result => this.products = result);
    this.catalogService.numberOfPages.subscribe(result => this.numberOfPages = result);

    this.catalogService.pagesOutput.subscribe(response => {
        this.products = response.products;
        this.totalCount = response.totalCount;
    });
   
    this.catalogService.getPage(1);  
  }

  editClicked(index: number) {
    const product = this.products[index];
    const id = product.productId;
    this.router.navigateByUrl('/edit/' + id );
  }

  deleteClicked(event: any) {

    if (confirm("Are you sure?")) {
    const productId = this.products[event].productId;
    this.catalogService.deleteProduct(productId)
      .subscribe(
        {
          next: response => {
           this.catalogService.getPage(1);
          },
          error: error => { console.log('There was and error loading product! ', error) },

        });
  }
}

onPageChange(page){
  this.catalogService.getPage(page); 

}

}




