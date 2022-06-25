import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { Product } from '../models/product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  constructor(private http: HttpClient) { }
  getAllProducts(): Observable<Product[]> {
    return this.http.get<Product[]>( 'https://fakestoreapi.com/products/');
  }
  getProductDetails(id:number): Observable<Product> {
    return this.http.get<Product>( 'https://fakestoreapi.com/products/'+id);
  }
}
