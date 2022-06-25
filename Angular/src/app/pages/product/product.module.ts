
import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { SharedModule } from 'src/app/common/shared.module';
import { ProductRoutingModule } from './product-routing.module';
import { ProductListComponent } from './product-list/product-list.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { ProductService } from './services/product-service.service';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    ProductListComponent,
    ProductDetailsComponent
  ],
  imports: [
    RouterModule,
    FormsModule,
    SharedModule,
    HttpClientModule,
    CommonModule,
    ProductRoutingModule
  ],
  providers:[
    ProductService]
})
export class ProductModule { }
