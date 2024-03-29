import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from 'src/interfaces/product';
import { CatalogService } from '../catalog.service';
import { CurrencyPipe } from '@angular/common';

@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.css']
})
export class EditProductComponent {

  product: Product;
  currentPage = 1;
  editForm: FormGroup;
  constructor(private router: Router,
    private route: ActivatedRoute,
    private catalogService: CatalogService) { }



  ngOnInit() {
    this.route.params.subscribe(({ id }) => {
      this.product = this.catalogService.products.find(product => product.productId === id);
    });

    this.catalogService.pagesInput.subscribe((page) => {
      this.currentPage = page;
    }) ;

    const { productId, code, name, price } = this.product;

    this.editForm = new FormGroup({
      productId: new FormControl(productId, [Validators.required,]),
      code: new FormControl(code, [Validators.required,]),
      name: new FormControl(name, [Validators.required,]),
      price: new FormControl(price, [Validators.required, Validators.pattern(/^(?:\d*\.\d{1,2}|\d+)$/)]),
    });
  }


  onSubmit() {
    if (!this.editForm.valid) {
      return;
    }
    this.catalogService.editProduct(this.editForm.value)
      .subscribe(
        {
          next: response => {
            this.catalogService.getPage(this.currentPage);
          },
          error: error => { console.log('There was and error loading product! ', error) },

        });


    this.router.navigateByUrl('/');

  }

  closeForm() {
    this.router.navigateByUrl('/');
  }

}
