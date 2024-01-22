import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateProductComponent } from './create-product/create-product.component';
import { EditProductComponent } from './edit-product/edit-product.component';
import { ProductListComponent } from './product-list/product-list.component';
import { PlaceholderComponent } from './placeholder/placeholder.component';

const routes: Routes = [
  { path: '', component: ProductListComponent, 
  children: [
    {path: '', component: PlaceholderComponent},
    {path: 'create', component: CreateProductComponent },
    {path: 'edit/:id', component: EditProductComponent},
  ]}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
