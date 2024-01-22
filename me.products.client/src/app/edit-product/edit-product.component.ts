import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from 'src/interfaces/product';
import { CatalogService } from '../catalog.service';

@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.css']
})
export class EditProductComponent {

  product: Product;
  editForm: FormGroup;
  constructor(private router: Router,
              private route: ActivatedRoute,
              private catalogService: CatalogService) { }



  ngOnInit() {
    this.route.params.subscribe(({ id }) => {
      this.product = this.catalogService.products.find(product => product.productId === id);
    });

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
    this.catalogService.editProduct(this.editForm.value);
    this.router.navigateByUrl('/');

  }

  closeForm() {
    this.router.navigateByUrl('/');
  }

}
