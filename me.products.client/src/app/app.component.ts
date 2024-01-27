import { Component } from '@angular/core';
import { CatalogService } from './catalog.service';
import { Product } from '../interfaces/product';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
 
  editedProduct: Product;
  editing = false;
  creating = false;

  constructor(private catalogService: CatalogService) { }

  ngOnInit() {

      //.subscribe(
      //{
      //  next: response => { this.products = response },
      //  error: error => { console.log('There was and error loading product! ', error) },

      //});
  };

  //onSubmitCreate(value: Product) {
  //  this.catalogService.createProduct(value).subscribe(response => {
  //    if (response.product) {
  //      this.products = [...this.products, response.product];
  //      this.creating = false;
  //    }

  //  },);

  //}

  //onSubmitEdit(value: Product) {
  //  this.catalogService.editProduct(value).subscribe(response => {
  //    this.catalogService.getProducts().subscribe(response => {
  //      this.products = response;
  //      this.editing = false;
  //    });
  //  });

  //}

  //onDeleteProduct(id: string) {
  //  this.catalogService.deleteProduct(id).subscribe(response => {
  //    this.catalogService.getProducts().subscribe(response => {
  //      this.products = response;

  //    });
  //  });
  //}
  //onEditProduct(product: Product) {
  //  this.editedProduct = product;
  //  this.editing = !this.editing;

  //}
  //onCancelEdit() {
  //  this.editing = false;
  //}
  //onCancelCreate() {
  //  this.creating = false;
  //}

}



