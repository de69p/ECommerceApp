import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable, throwError} from 'rxjs';
import {catchError} from 'rxjs/operators';
import {CartItem} from "../models/cart.model";
import {Product} from "../models/product.model";

@Injectable({
  providedIn: 'root'
})
export class CartService {

  constructor(private http: HttpClient) {
  }

  addToCart(product: Product): Observable<void> {
    return this.http.post<void>('https://localhost:7113/api/cart', {productId: product.id, product, quantity: 1}).pipe(
      catchError(err => {
        console.error(err);
        return throwError(() => err);
      })
    );
  }

  getCartItems(): Observable<CartItem[]> {
    return this.http.get<CartItem[]>('https://localhost:7113/api/cart').pipe(
      catchError(err => {
        console.error();
        return throwError(() => err);
      })
    );
  }

  removeFromCart(id: number): Observable<void> {
    return this.http.delete<void>(`https://localhost:7113/api/cart/${id}`).pipe(
      catchError(err => {
        console.error();
        return throwError(() => err);
      })
    );
  }

  updateQuantity(id: number, newQuantity: number): Observable<void> {
    return this.http.put<void>(`https://localhost:7113/api/cart/${id}`, {newQuantity}).pipe(
      catchError(err => {
        console.error();
        return throwError(() => err);
      })
    );
  }
}
