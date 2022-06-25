import { Component, OnInit } from '@angular/core';
import { Product } from '../models/product';
import { ProductService } from '../services/product-service.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  isLoading:boolean = false;
  constructor(private _productService:ProductService) { }
  public allProductList: Product[] = [];
  public productList: Product[] = [];
  currentPage=0;
   list=[{
    "id": 1,
    "title": "Product 1",
    "price": 123,
    "description": "stri ngs ringstring stringstringstr ing",
    "category": "Product",
    "image": "assets/image1.jpg",
    "rating": {
      "rate": 3,
      "count": 3
    }
  },
  {
    "id": 2,
    "title": "Product 2",
    "price": 123456,
    "description": "Product",
    "category": "string",
    "image": "assets/image2.jpg",
    "rating": {
      "rate": 1,
      "count": 1
    }
  },{
    "id": 2,
    "title": "Product 2",
    "price": 123456,
    "description": "Product",
    "category": "string",
    "image": "assets/image2.jpg",
    "rating": {
      "rate": 1,
      "count": 1
    }
  },{
    "id": 2,
    "title": "Product 2",
    "price": 123456,
    "description": "Product",
    "category": "string",
    "image": "assets/image2.jpg",
    "rating": {
      "rate": 1,
      "count": 1
    }
  },{
    "id": 2,
    "title": "Product 2",
    "price": 123456,
    "description": "Product",
    "category": "string",
    "image": "assets/image2.jpg",
    "rating": {
      "rate": 1,
      "count": 1
    }
  },{
    "id": 2,
    "title": "Product 2",
    "price": 123456,
    "description": "Product",
    "category": "string",
    "image": "assets/image2.jpg",
    "rating": {
      "rate": 1,
      "count": 1
    }
  },{
    "id": 2,
    "title": "Product 2",
    "price": 123456,
    "description": "Product",
    "category": "string",
    "image": "assets/image2.jpg",
    "rating": {
      "rate": 1,
      "count": 1
    }
  },{
    "id": 2,
    "title": "Product 2",
    "price": 123456,
    "description": "Product",
    "category": "string",
    "image": "assets/image2.jpg",
    "rating": {
      "rate": 1,
      "count": 1
    }
  },{
    "id": 2,
    "title": "Product 2",
    "price": 123456,
    "description": "Product",
    "category": "string",
    "image": "assets/image2.jpg",
    "rating": {
      "rate": 1,
      "count": 1
    }
  },{
    "id": 2,
    "title": "Product 2",
    "price": 123456,
    "description": "Product",
    "category": "string",
    "image": "assets/image2.jpg",
    "rating": {
      "rate": 1,
      "count": 1
    }
  },{
    "id": 2,
    "title": "Product 2",
    "price": 123456,
    "description": "Product",
    "category": "string",
    "image": "assets/image2.jpg",
    "rating": {
      "rate": 1,
      "count": 1
    }
  },{
    "id": 2,
    "title": "Product 2",
    "price": 123456,
    "description": "Product",
    "category": "string",
    "image": "assets/image2.jpg",
    "rating": {
      "rate": 1,
      "count": 1
    }
  },{
    "id": 2,
    "title": "Product 2",
    "price": 123456,
    "description": "Product",
    "category": "string",
    "image": "assets/image2.jpg",
    "rating": {
      "rate": 1,
      "count": 1
    }
  },{
    "id": 2,
    "title": "Product 2",
    "price": 123456,
    "description": "Product",
    "category": "string",
    "image": "assets/image2.jpg",
    "rating": {
      "rate": 1,
      "count": 1
    }
  },{
    "id": 2,
    "title": "Product 2",
    "price": 123456,
    "description": "Product",
    "category": "string",
    "image": "assets/image2.jpg",
    "rating": {
      "rate": 1,
      "count": 1
    }
  },{
    "id": 2,
    "title": "Product 2",
    "price": 123456,
    "description": "Product",
    "category": "string",
    "image": "assets/image2.jpg",
    "rating": {
      "rate": 1,
      "count": 1
    }
  },{
    "id": 2,
    "title": "Product 2",
    "price": 123456,
    "description": "Product",
    "category": "string",
    "image": "assets/image2.jpg",
    "rating": {
      "rate": 1,
      "count": 1
    }
  },
  ]
  ngOnInit(): void {
    this.isLoading = true;
    // this._productService.getAllProducts().subscribe(res=>{
    //   this.allProductList = res;
    //   this.nextProduct();
    //   this.isLoading = false;
    // })
    this.allProductList = this.list;
    this.nextProduct();
    this.isLoading = false;
  }
  pageLength:number =6;
  nextProduct(){
  if((this.currentPage*this.pageLength)<this.allProductList.length){
    this.productList = this.allProductList.slice(this.currentPage*this.pageLength,(this.currentPage+1)*this.pageLength);
    this.currentPage++;
  }
  }
  previousProduct(){
    if(this.currentPage>1){
      this.productList = this.allProductList.slice((this.currentPage-2)*this.pageLength,(this.currentPage-1)*this.pageLength);
      this.currentPage--;
    }
  }
  checkRecord(){
    if((this.currentPage)*this.pageLength<=this.allProductList.length){
      return (this.currentPage)*this.pageLength;
    }
    else{
      return  this.allProductList.length
    }
  }
  details=false;
  pDetails:any;
  showDetails(item:any){
    this.isLoading = true;
    this._productService.getProductDetails(item.id).subscribe(res=>{
      this.details=true;
      this.pDetails=res;
      this.isLoading = false;
    })
    this.details=true;
this.pDetails=item;
this.isLoading = false;
  }
  closeDetails(){
    this.details=false;
  this.pDetails=null;
  }
  }

