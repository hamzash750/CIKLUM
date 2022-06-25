import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Product } from '../models/product';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {
  @Output() productInformation = new EventEmitter<any>();
  constructor() { }
 @Input() product!:Product;
  discount=0;
 calculateDiscountInPercentage(price:number=0){
 if(this.discount>0){
  let discountPrice=(price*this.discount)/100
  let amount= (price-discountPrice);
  return amount>0?amount:0;
 }else{
  return price;
 }
  }
  ngOnInit(): void {
  }
closeDetailsDiv(){
  this.productInformation.emit(false);
}
  checkProductRating(rating:number=0){
    if(rating>=1){
      return true;
    }
    else if(rating>=2){
      return true;
    }
    else if(rating>=3){
      return true;
    }
    else if(rating>=4){
      return true;
    }
    else if(rating>=5){
      return true;
    }
    else{
      return false;
    }
  }
}
