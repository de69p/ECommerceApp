import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';  // import throwError
import { catchError } from 'rxjs/operators';
import { Product } from '../models/product.model';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http: HttpClient) { }

  getProducts(type: string | null = null): Observable<Product[]> {
    let url = 'https://localhost:7113/api/products';
    if (type) {
      url += `?type=${type}`;
    }
    return this.http.get<Product[]>(url).pipe(
      catchError(err => {
        console.error(err);
        return throwError(() => err);
      })
    );
  }




}
