import { Component} from '@angular/core';
import { FormGroup,FormControl, Validators } from '@angular/forms';
import {  Router } from '@angular/router';
import { CatalogService } from '../catalog.service';

@Component({
  selector: 'app-create-product',
  templateUrl: './create-product.component.html',
  styleUrls: ['./create-product.component.css']
})
export class CreateProductComponent {
  
  createForm: FormGroup = new FormGroup({
    code: new FormControl("",[Validators.required,]),
    name: new FormControl("",[Validators.required,]),
    price: new FormControl("",[Validators.required, Validators.pattern(/^(?:\d*\.\d{1,2}|\d+)$/)]),
  }); 

  
  constructor(private router: Router, private catalogService: CatalogService) { }
  
  onSubmit(){
    if (!this.createForm.valid) {
      return;
    }
    this.catalogService.createProduct(this.createForm.value)
      .subscribe(
        {
          next: response => {
          this.catalogService.getPage(1);  
          },
          error: error => { console.log('There was and error loading product! ', error) },

        });


    this.router.navigateByUrl('/');
   
  }

  closeForm(){
    this.router.navigateByUrl('/');
  }




}
