import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Product } from 'src/interfaces/product';
import { CatalogService } from '../catalog.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent {

  products: Product[];
  constructor(private router: Router,
    private catalogService: CatalogService) { }


  ngOnInit() {
    this.catalogService.getProducts();
    this.catalogService.productsChanged.subscribe(products => this.products = products);
  }

  editClicked(index: number) {
    const product = this.products[index];
    const id = product.productId;
    this.router.navigateByUrl('/edit/'+id);
  }

  deleteClicked(event:any){
    const productId = this.products[event].productId;
    this.catalogService.deleteProduct(productId);

  }



}
